
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reactive.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Helpers;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Commands.Functionality;
using DataBase.QueriesAndCommands.Commands.History;
using DataBase.QueriesAndCommands.Commands.Media;
using DataBase.QueriesAndCommands.Commands.Settings;
using DataBase.QueriesAndCommands.Commands.Users;
using DataBase.QueriesAndCommands.Queries.Features;
using DataBase.QueriesAndCommands.Queries.Functionality;
using DataBase.QueriesAndCommands.Queries.HashTag;
using DataBase.QueriesAndCommands.Queries.Languages;
using DataBase.QueriesAndCommands.Queries.Media;
using DataBase.QueriesAndCommands.Queries.Settings;
using DataBase.QueriesAndCommands.Queries.Users;
using DataBase.QueriesAndCommands.Queries.Words;
using Engines.Engines.AddCommentEngine;
using Engines.Engines.FollowUserEngine;
using Engines.Engines.GetMediaByHashTagEngine;
using Engines.Engines.GetMediaByMainPageEngine;
using Engines.Engines.GetUserInfoEngine;
using Engines.Engines.LikeMediaEngine;
using Engines.Engines.RegistrationEngine;
using Engines.Engines.SearchUserFriendsEngine;
using Engines.Engines.WaitingCaptchEngine;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using RestSharp;
using ServiceStack.Api.Postman;
using ServiceStack.ServiceInterface.Cors;
using Cookie = System.Net.Cookie;

namespace InstagramApp
{
    public class InstagramService
    {
        public FunctionalityWithTokenModel GetFreeFunctionality(RemoteWebDriver driver, DataBaseContext context)
        {
            var functionalityToRun = new GetFunctionalityToRunQueryHandler(context).Handle(new GetFunctionalityToRunQuery
            {
                
            });

            return functionalityToRun;
        }

        public bool FunctionalityIsAllowed(RemoteWebDriver driver, DataBaseContext context,
            FunctionalityWithTokenModel functionalityModel)
        {
            var access = new CheckFunctionalityAccessQueryHandler(context).Handle(new CheckFunctionalityAccessQuery
            {
                FunctionalityName = functionalityModel.FunctionalityName,
                Token = functionalityModel.Token
            });

            return access;
        }

        public void LeaveFunctionality(RemoteWebDriver driver, DataBaseContext context,
            FunctionalityWithTokenModel functionalityModel)
        {
            new RemoveFunctionalityTokenCommandHandler(context).Handle(new RemoveFunctionalityTokenCommand
            {
                FunctionalityName = functionalityModel.FunctionalityName
            });
        }

        private void Registration(RemoteWebDriver driver, DataBaseContext context)
        {
            var settings = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());

            new RegistrationEngine().Execute(driver, new RegistrationModel
            {
                UserName = settings.Login,
                Password = settings.Password
            });
        }

        public void UnfollowUsers(RemoteWebDriver driver, DataBaseContext context)
        {
            Registration(driver, context);

            var users = new GetUsersToUnFollowQueryHandler(context).Handle(new GetUsersToUnFollowQuery { MaxCount = 1000, BanTime = new TimeSpan(1, 0, 0, 0)});

            foreach (var user in users)
            {
                new UnFollowUserEngine().Execute(driver, new UnFollowUserModel()
                {
                    UserLink = user
                });

                new MarkUserAsBannedCommandHandler(context).Handle(new MarkUserAsBannedCommand
                {
                    User = user
                });
            }
        }

        public void FollowUsers(RemoteWebDriver driver, DataBaseContext context)
        {
            Registration(driver, context);

            var users = new GetUsersToFollowQueryHandler(context).Handle(new GetUsersToFollowQuery { MaxCount = 100 });

            foreach (var user in users)
            {
                FollowUser(driver, context, user);
            }
        }

        public void SearchNewUsers(RemoteWebDriver driver, DataBaseContext context)
        {
            Registration(driver, context);

            var users = new GetUsersNotCheckedForFriendsQueryHandler(context).Handle(new GetUsersNotCheckedForFriendsQuery { MaxCount = 1 });

            var results = new List<string>();

            foreach (var user in users)
            {
                var userInfo = new GetUserInfoEngine().Execute(driver, new GetUserInfoEngineModel
                {
                    UserLink = user
                });

                results.AddRange(new SearchUserFollowingsEngine().Execute(driver, new SearchUserFollowingsModel
                {
                    UserLink = user,
                    MaxCount = 250,
                    Count = userInfo.FollowerCount
                }));

                results.AddRange(new SearchUserUnAddedFriendsEngine().Execute(driver, new SearchUserUnAddedFriendsModel
                {
                    UserLink = user,
                    MaxCount = 250,
                    Count = userInfo.FollowingCount
                }));
            }

            var knownUsers = new GetAllKnownUsersQueryHandler(context).Handle(new GetAllKnownUsersQuery());

            var usersToMark = results.Except(knownUsers).ToList();

            foreach (var userToMark in usersToMark)
            {
                new MarkUserAsToFollowCommandHandler(context).Handle(new MarkUserAsToFollowCommand
                {
                    UserLink = userToMark
                });
            }

            foreach (var user in users)
            {
                new MarkUserAsCheckedForFriendsCommandHandler(context).Handle(new MarkUserAsCheckedForFriendsCommand
                {
                    User = user
                });
            }
        }

        public void SynchOwnerFriends(RemoteWebDriver driver, DataBaseContext context)
        {
            Registration(driver, context);

            var settings = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());

            var userInfo = new GetUserInfoEngine().Execute(driver, new GetUserInfoEngineModel
            {
                UserLink = settings.HomePageUrl
            });

            var addedUsers = new SearchUserFollowingsEngine().Execute(driver, new SearchUserFollowingsModel
            {
                UserLink = settings.HomePageUrl,
                MaxCount = null,
                Count = userInfo.FollowerCount
            });

            var spammerUsers = new GetSpammerUsersQueryHandler(context).Handle(new GetSpammerUsersQuery());

            var usersToAdd = addedUsers.Except(spammerUsers).ToList();

            var foreigners = new GetForeignUsersQueryHandler(context).Handle(new GetForeignUsersQuery());

            usersToAdd = usersToAdd.Except(foreigners).ToList();

            foreach (var user in usersToAdd)
            {
                AddUser(driver, context, user);
            }
        }

        private IEnumerable<string> ParseDataFromFile(string fileName)
        {
            var directory = Directory.GetCurrentDirectory();
            var path = Path.Combine(directory, "Kioto", fileName);

            var pattern = "username[^,]*";
            var regex = new Regex(pattern);

            using (var firstFileReader = new StreamReader(path))
            {
                while (!firstFileReader.EndOfStream)
                {
                    var line = firstFileReader.ReadLine();
                    var parsedData = regex.Match(line).Value;

                    if (!string.IsNullOrWhiteSpace(parsedData))
                    {
                        var result = Path.Combine("https://www.instagram.com", parsedData.Split('\"')[2]);
                        yield return result;
                    }
                }
            }
        }

        private IEnumerable<string> ParseFromResponse(string response)
        {
            var pattern = "username[^,]*";
            var regex = new Regex(pattern);

            foreach (Match line in regex.Matches(response))
            {
                if (!string.IsNullOrWhiteSpace(line.Value))
                {
                    var result = Path.Combine("https://www.instagram.com", line.Value.Split('\"')[2]);
                    yield return result;
                }
            }
        }

        public void ClearUselessUsers(RemoteWebDriver driver, DataBaseContext context)
        {
            Registration(driver, context);

            var settings = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());

            var userInfo = new GetUserInfoEngine().Execute(driver, new GetUserInfoEngineModel
            {
                UserLink = settings.HomePageUrl
            });

            new SearchUserFollowingsEngine().Execute(driver, new SearchUserFollowingsModel
            {
                UserLink = settings.HomePageUrl
            });

            /*var followersButton = driver
                .FindElements(By.ClassName("_s53mj"))
                .Where(element =>
                {
                    if (element.GetAttribute("href") != null)
                    {
                        return element.GetAttribute("href").ToLower().Contains("followers");
                    }
                    return false;
                })
                .FirstOrDefault();

            followersButton.Click();

            Thread.Sleep(1500);

            for (var i = 0; i < 3; i++)
            {
                Thread.Sleep(100);
                driver.Keyboard.SendKeys(Keys.PageDown);
            }

            var allCookies = driver.Manage().Cookies;
            var cookies = "mid" + "=" + allCookies.GetCookieNamed("mid").Value + "; " +
                          "sessionid" + "=" + allCookies.GetCookieNamed("sessionid").Value + "; " +
                          "csrftoken" + "=" + allCookies.GetCookieNamed("csrftoken").Value + "; " +
                          "s_network" + "=" + allCookies.GetCookieNamed("s_network").Value + "; " +
                          "ds_user_id" + "=" + allCookies.GetCookieNamed("ds_user_id").Value + "; " +
                          "ig_pr" + "=" + allCookies.GetCookieNamed("ig_pr").Value + "; " +
                          "ig_vw" + "=" + allCookies.GetCookieNamed("ig_vw").Value + "; ";

            cookies = cookies + cookies;

            var allcookies = driver.Manage().Cookies;
            var csfToken = allcookies.GetCookieNamed("csrftoken").Value;

            var clientRest = new RestClient("https://www.instagram.com/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var requestRest = new RestRequest("query/", Method.POST);
            requestRest.Parameters.Clear();

            requestRest.AddParameter("q",
                "ig_user(3647234619) {  follows.first(10) {    count,    page_info {      end_cursor,      has_next_page    },    nodes {      id,      is_verified,      followed_by_viewer,      requested_by_viewer,      full_name,      profile_pic_url,      username    }  }}");
            requestRest.AddParameter("ref", "relationships::follow_list");

            // add parameters for all properties on an object
            requestRest.AddCookie("mid", allCookies.GetCookieNamed("mid").Value);
            requestRest.AddCookie("sessionid", allCookies.GetCookieNamed("sessionid").Value);
            requestRest.AddCookie("csrftoken", allCookies.GetCookieNamed("csrftoken").Value);
            requestRest.AddCookie("s_network", allCookies.GetCookieNamed("s_network").Value);
            requestRest.AddCookie("ds_user_id", allCookies.GetCookieNamed("ds_user_id").Value);
            requestRest.AddCookie("ig_pr", allCookies.GetCookieNamed("ig_pr").Value);
            requestRest.AddCookie("ig_vw", allCookies.GetCookieNamed("ig_vw").Value);

            // easily add HTTP Headers
            requestRest.AddHeader("Origin", "https://www.instagram.com");
            requestRest.AddHeader("Referer", "https://www.instagram.com/kioto.grodno/followers/");
            requestRest.AddHeader("X-Instagram-AJAX", "1");
            requestRest.AddHeader("User-Agent",
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36");
            requestRest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            requestRest.AddHeader("X-Requested-With", "XMLHttpRequest");
            requestRest.AddHeader("X-CSRFToken", csfToken);
            requestRest.AddHeader("Accept-Encoding", "gzip, deflate, br");
            requestRest.AddHeader("Accept-Language", "ru-RU,ru;q=0.8,en-US;q=0.6,en;q=0.4");
            requestRest.AddHeader("Cookie", cookies);

            // execute the request
            IRestResponse responseRest = clientRest.Execute(requestRest);
            var content = responseRest.Content; // 

            var userList = ParseFromResponse(content);
            dynamic data = Json.Decode(content);
            var follows = data.follows;
            var count = int.Parse(follows.count.ToString());
            var pageInfo = follows.page_info;
            var endCursor = pageInfo.end_cursor.ToString();
            var hasNextPage = bool.Parse(pageInfo.has_next_page.ToString());
            /*var firstFollowersList = ParseDataFromFile("KarinaFollowers.txt");
            var secondFollowersList = ParseDataFromFile("KarinaFollowers2.txt");

            var firstFollowingList = ParseDataFromFile("KarinaFollowings.txt");
            var secondFollowingList = ParseDataFromFile("KarinaFollowings2.txt");
            var thirdFollowingList = ParseDataFromFile("KarinaFollowings3.txt");*/

            /*var addedUsers = firstFollowersList.Union(secondFollowersList);/*new SearchUserFriendsEngine().Execute(driver, new SearchUserFriendsModel
            {
                UserLink = settings.HomePageUrl,
                MaxCount = null,
                Count = userInfo.FollowerCount
            });*/

            /*var followings = firstFollowingList.Union(secondFollowingList).Union(thirdFollowingList);/*new SearchUserUnAddedFriendsEngine().Execute(driver, new SearchUserUnAddedFriendsModel
            {
                UserLink = settings.HomePageUrl,
                MaxCount = null,
                Count = userInfo.FollowingCount
            });*/

            /*var banList = followings.Except(addedUsers).Take(1000); // Max value;

            foreach (var userToDelete in banList)
            {
                new UnFollowUserEngine().Execute(driver, new UnFollowUserModel
                {
                    UserLink = userToDelete
                });

                new MarkUserAsSpammerCommandHandler(context).Handle(new MarkUserAsSpammerCommand
                {
                    UserLink = userToDelete
                });
            }*/
        }

        public void SynchOwnerFollowings(RemoteWebDriver driver, DataBaseContext context)
        {
            Registration(driver, context);

            var timeForSynchronization = new TimeForFollowingsSynchronizationQueryHandler(context).Handle(new TimeForFollowingsSynchronizationQuery());

            if (!timeForSynchronization)
            {
                return;
            }

            new UpdateFollowingsSynchronizationTimeCommandHandler(context).Handle(new UpdateFollowingsSynchronizationTimeCommand
            {
                NextTime = DateTime.Now
            });

            var settings = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());

            var userInfo = new GetUserInfoEngine().Execute(driver, new GetUserInfoEngineModel
            {
                UserLink = settings.HomePageUrl
            });

            var followings = new SearchUserUnAddedFriendsEngine().Execute(driver, new SearchUserUnAddedFriendsModel
            {
                UserLink = settings.HomePageUrl,
                MaxCount = null,
                Count = userInfo.FollowingCount
            });

            var knownUsers = new GetAllKnownUsersQueryHandler(context).Handle(new GetAllKnownUsersQuery());

            var toFollowUsers = followings.Except(knownUsers).ToList();

            foreach (var userToFollow in toFollowUsers)
            {
                new MarkUserAsToFollowCommandHandler(context).Handle(new MarkUserAsToFollowCommand
                {
                    UserLink = userToFollow
                });
            }
        }

        public void ChangeUserStatus(RemoteWebDriver driver, DataBaseContext context, string user,
            Action markStatus)
        {
            var userInfo = new GetUserInfoEngine().Execute(driver, new GetUserInfoEngineModel
            {
                UserLink = user
            });

            if (userInfo.IsStar)
            {
                new FollowUserEngine().Execute(driver, new FollowUserModel
                {
                    UserLink = user
                });

                new MarkUserAsStarCommandHandler(context).Handle(new MarkUserAsStarCommand
                {
                    UserLink = user
                });

                return;
            }

            var access = new CheckFeaturesAccessQueryHandler(context).Handle(new CheckFeaturesAccessQuery()
            {
                FeaturesName = FeaturesName.CheckSpammers
            });

            if (access && UserIsSpammer(driver, context, userInfo))
            {
                new UnFollowUserEngine().Execute(driver, new UnFollowUserModel
                {
                    UserLink = user
                });

                new MarkUserAsSpammerCommandHandler(context).Handle(new MarkUserAsSpammerCommand
                {
                    UserLink = user
                });

                return;
            }

            if (UserIsForeign(driver, context, userInfo))
            {
                new UnFollowUserEngine().Execute(driver, new UnFollowUserModel
                {
                    UserLink = user
                });

                new MarkUserAsForeignerCommandHandler(context).Handle(new MarkUserAsForeignerCommand
                {
                    UserLink = user
                });

                return;
            }

            new FollowUserEngine().Execute(driver, new FollowUserModel
            {
                UserLink = user
            });

            markStatus();
        }

        public void AddUser(RemoteWebDriver driver, DataBaseContext context, string user)
        {
            ChangeUserStatus(driver, context, user,
                () => new MarkUserAsAddedCommandHandler(context).Handle(new MarkUserAsAddedCommand
                {
                    UserLink = user
                }));
        }

        public void FollowUser(RemoteWebDriver driver, DataBaseContext context, string user)
        {
            ChangeUserStatus(driver, context, user,
                () => new MarkUserAsFollowingCommandHandler(context).Handle(new MarkUserAsFollowingCommand
                {
                    UserLink = user
                }));
        }

        public void SaveMediaByHashTag(RemoteWebDriver driver, DataBaseContext context)
        {
            Registration(driver, context);

            var hasTags = new GetHashTagsQueryHandler(context).Handle(new GetHashTagsQuery());

            foreach (var hasTag in hasTags)
            {
                var mediaList = new GetMediaByHashTagEngine().Execute(driver, new GetMediaByHashTagModel()
                {
                    HashTag = hasTag,
                    CountMedia = 20
                });

                new AddMediaListCommandHandler(context).Handle(new AddMediaListCommand
                {
                    MediaList = mediaList,
                    MediaStatus = MediaStatus.ToLike
                }); 
            }   
        }

        public void SaveMediaByHomePage(RemoteWebDriver driver, DataBaseContext context)
        {
            Registration(driver, context);

            var mediaList = new GetMediaByMainPageEngine().Execute(driver, new GetMediaByMainPageModel()
            {
                    CountMedia = 30
            });

            new AddMediaListCommandHandler(context).Handle(new AddMediaListCommand
            {
                MediaList = mediaList,
                MediaStatus = MediaStatus.ToLike
            });
        }

        public void LikeMedias(RemoteWebDriver driver, DataBaseContext context)
        {
            Registration(driver, context);

            var hashTags = new GetMediaToLikeQueryHandler(context).Handle(new GetMediaToLikeQuery
            {
                MaxCount = 150
            });

            foreach (var hashTag in hashTags)
            {
                var userLink = new LikeMediaEngine().Execute(driver, new LikeMediaModel
                {
                    Link = hashTag
                });

                new MarkMediaAsLikedCommandHandler(context).Handle(new MarkMediaAsLikedCommand
                {
                    Link = hashTag
                });

                if (!string.IsNullOrEmpty(userLink.UserLink))
                {
                    new MarkUserAsToFollowCommandHandler(context).Handle(new MarkUserAsToFollowCommand
                    {
                        UserLink = userLink.UserLink
                    });
                }
            }
        }

        public void ClearOldMedia(RemoteWebDriver driver, DataBaseContext context)
        {
            Registration(driver, context);

            new DeleteMediaCommandHandler(context).Handle(new DeleteMediaCommand
            {
                UrlList = new GetMediaToDeleteQueryHandler(context).Handle(new GetMediaToDeleteQuery())
            });
        }
        
        public void AddComments(RemoteWebDriver driver, DataBaseContext context)
        {
            Registration(driver, context);
            
            var access = new CheckFeaturesAccessQueryHandler(context).Handle(new CheckFeaturesAccessQuery()
            {
                FeaturesName = FeaturesName.PostComments
            });

            if (access)
            {
                var mediaList =
                    new GetRandomMediaListToCommentQueryHandler(context).Handle(new GetRandomMediaListToCommentQuery()
                    {
                        CountMedia = 3
                    });

                foreach (var media in mediaList)
                {
                    new AddCommentEngine().Execute(driver, new AddCommentModel
                    {
                        CommentText = "Всем привет! Старые методы накрутки подписчиков ушли в прошлое! Только \"живая\" целевая аудитория! Подробности в профиле!",
                        Link = media
                    });

                    new MarkMediaAsHavingCommentCommandHandler(context).Handle(new MarkMediaAsHavingCommentCommand()
                    {
                        Link = media
                    });
                }
            }

        }

        public void AddFollowersNote(RemoteWebDriver driver, DataBaseContext context)
        {
            Registration(driver, context);

            var settings = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());

            var userInfo = new GetUserInfoEngine().Execute(driver, new GetUserInfoEngineModel
            {
                UserLink = settings.HomePageUrl
            });

            new AddFollowersNoteCommandHandler(context).Handle(new AddFollowersNoteCommand
            {
                FollowersCount = userInfo.FollowerCount
            });
        }

        public void HandleCaptchaException(RemoteWebDriver driver, DataBaseContext context)
        {
            //todo: Add sending mail notification

            Registration(driver, context);

            var testLink = new GetTechnicalUsersQueryHandler(context).Handle(new GetTechnicalUsersQuery { MaxCount = 1 }).FirstOrDefault();

            new WaitingCaptchaEngine().Execute(driver, new WaitingCaptchaEngineModel
            {
                TestLink = testLink
            });
        }

        public bool UserIsSpammer(RemoteWebDriver driver, DataBaseContext context, GetUserInfoEngineResponse userInfo)
        {
            const int MaxFollowingCount = 5000;
            const double ExtraFollowingPenalty = 0.001;
            const int MaxFollowerCount = 5000;
            const double ExtraFollowerPenalty = 0.001;
            const double MaxPenalty = 1.5;

            var spamWords = new GetSpamWordsQueryHandler(context).Handle(new GetSpamWordsQuery());

            var factor = 0.0;
            if (!string.IsNullOrWhiteSpace(userInfo.Text))
            {
                var text = userInfo.Text.ToLower();

                factor = spamWords
                    .Where(spamWord => text.Contains(spamWord.WordRoot))
                    .Sum(spamWord => spamWord.SpamFactor);
            }

            factor += Math.Max(0, userInfo.FollowingCount - MaxFollowingCount) * ExtraFollowingPenalty;
            factor += Math.Max(0, userInfo.FollowerCount - MaxFollowerCount) * ExtraFollowerPenalty;

            return factor > MaxPenalty;
        }

        public bool UserIsForeign(RemoteWebDriver driver, DataBaseContext context, GetUserInfoEngineResponse userInfo)
        {
            if (string.IsNullOrWhiteSpace(userInfo.Text))
            {
                return false;
            }

            var languages = new GetLanguagesQueryHandler(context).Handle(new GetLanguagesQuery());

            var settings = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());

            var languageInfo = new LanguageDetector.LanguageDetector().Detect(userInfo.Text, settings.LanguageDetectorKey);

            if (languageInfo == null)
            {
                return false;
            }

            return !languages.Contains(languageInfo.language);
        }
    }
}
