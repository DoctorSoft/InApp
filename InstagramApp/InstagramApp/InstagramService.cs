
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Script.Serialization;
using Constants;
using DataBase.Contexts.InnerTools;
using DataBase.Contexts.InnerTools.StoreContexts;
using DataBase.QueriesAndCommands.Commands.Functionality;
using DataBase.QueriesAndCommands.Commands.History;
using DataBase.QueriesAndCommands.Commands.Media;
using DataBase.QueriesAndCommands.Commands.Register;
using DataBase.QueriesAndCommands.Commands.Settings;
using DataBase.QueriesAndCommands.Commands.Stars;
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
using Engines.Engines.DetectLanguageEngine;
using Engines.Engines.FollowUserEngine;
using Engines.Engines.GetMediaByHashTagEngine;
using Engines.Engines.GetMediaByMainPageEngine;
using Engines.Engines.GetUserIdEngine;
using Engines.Engines.GetUserInfoEngine;
using Engines.Engines.LikeMediaEngine;
using Engines.Engines.RegistrationEngine;
using Engines.Engines.SearchUserFriendsEngine;
using Engines.Engines.SetProxyEngine;
using Engines.Engines.WaitingCaptchEngine;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace InstagramApp
{
    public class InstagramService
    {
        public RemoteWebDriver RegisterNewDriver(ISettingsContext context)
        {
            var settings = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());

            if (string.IsNullOrWhiteSpace(settings.Proxy))
            {
                return new ChromeDriver();
            }

            var proxy = new Proxy { SslProxy = settings.Proxy };

            var chromeOptions = new ChromeOptions { Proxy = proxy };

            var driver = new ChromeDriver(chromeOptions);

            new SetProxyEngine().Execute(driver, new SetProxyEngineModel
            {
                ProxyLogin = settings.ProxyLogin,
                ProxyPassword = settings.ProxyPassword
            });

            return driver;
        }

        public FunctionalityWithTokenModel GetFreeFunctionality(RemoteWebDriver driver, DataBaseContext context)
        {
            var functionalityToRun = new GetFunctionalityToRunQueryHandler(context).Handle(new GetFunctionalityToRunQuery());

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

        private class CookieMainData
        {
            public string Name { get; set; }

            public DateTime? Expiry { get; set; }

            public string Domain { get; set; }

            public string Path { get; set; }

            public string Value { get; set; }
        }

        public void SwitchFollowingPolicy(DataBaseContext context)
        {
            var nowHour = DateTime.Now.Hour;

            var settings = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());

            var functionalities = new GetFunctionalityStatisticQueryHandler(context).Handle(new GetFunctionalityStatisticQuery
            {

            });

            var functionalityToFollow = functionalities.FirstOrDefault(statistic => statistic.FunctionalityName == FunctionalityName.FollowUsers);
            var functionalityToUnfollow = functionalities.FirstOrDefault(statistic => statistic.FunctionalityName == FunctionalityName.UnfollowUsers);

            if (functionalityToUnfollow == null || functionalityToFollow == null)
            {
                return;
            }

            if (!settings.SwitchingEnabled)
            {
                return;
            }

            if (settings.FollowingStartHour == nowHour)
            {
                if (functionalityToFollow.Stopped)
                {
                    new SwitchFunctionalityAccessCommandHandler(context).Handle(new SwitchFunctionalityAccessCommand
                    {
                        FunctionalityName = functionalityToFollow.FunctionalityName
                    });
                }
                if (!functionalityToUnfollow.Stopped)
                {
                    new SwitchFunctionalityAccessCommandHandler(context).Handle(new SwitchFunctionalityAccessCommand
                    {
                        FunctionalityName = functionalityToUnfollow.FunctionalityName
                    });
                }
            }

            if (settings.UnfollowingStartHour == nowHour)
            {
                if (functionalityToUnfollow.Stopped)
                {
                    new SwitchFunctionalityAccessCommandHandler(context).Handle(new SwitchFunctionalityAccessCommand
                    {
                        FunctionalityName = functionalityToUnfollow.FunctionalityName
                    });
                }
                if (!functionalityToFollow.Stopped)
                {
                    new SwitchFunctionalityAccessCommandHandler(context).Handle(new SwitchFunctionalityAccessCommand
                    {
                        FunctionalityName = functionalityToFollow.FunctionalityName
                    });
                }
            }

        }

        public void Registration(RemoteWebDriver driver, ISettingsContext context)
        {
            var settings = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());

            var driverCookies = driver.Manage().Cookies.AllCookies;

            if (!string.IsNullOrWhiteSpace(settings.Cookies) && driverCookies.All(cookie => cookie.Name != "mid"))
            {
                var cookieData = new JavaScriptSerializer().Deserialize<List<CookieMainData>>(settings.Cookies);

                driver.Navigate().GoToUrl("https://www.instagram.com/");
                foreach (var cookie in cookieData)
                {
                    try
                    {
                        var cookieValue = new Cookie(cookie.Name, cookie.Value, cookie.Domain, cookie.Path, cookie.Expiry);
                        driver.Manage().Cookies.AddCookie(cookieValue);
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            new RegistrationEngine().Execute(driver, new RegistrationModel
            {
                UserName = settings.Login,
                Password = settings.Password
            });

            var refreshedCookies = new JavaScriptSerializer().Serialize(driver.Manage().Cookies.AllCookies);

            new UpdateCookiesCommandHandler(context).Handle(new UpdateCookiesCommand
            {
                Cookies = refreshedCookies
            });
        }

        public void UnfollowUsers(RemoteWebDriver driver, DataBaseContext context)
        {
            UnfollowUsers(driver, context, 3);
        }

        public void UnfollowUsers(RemoteWebDriver driver, DataBaseContext context, int attempts)
        {
            var settings = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());
            
            if (attempts == 3)
            {
                new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                {
                    Note = "Start unfollowing users",
                    Name = FunctionalityName.UnfollowUsers,
                    WorkStatus = WorkStatus.Started
                });

                Registration(driver, context);

                var userInfo = new GetUserInfoEngine().Execute(driver, new GetUserInfoEngineModel
                {
                    UserLink = settings.HomePageUrl
                });

                if (userInfo.FollowingCount < settings.MinUsersToFollowCount)
                {
                    new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                    {
                        Note = "Stop unfollowing users",
                        Name = FunctionalityName.UnfollowUsers,
                        WorkStatus = WorkStatus.Cancelled
                    });

                    return;
                }
            }

            var users = new GetUsersToDeleteQueryHandler(context).Handle(new GetUsersToDeleteQuery
            {
                MaxCount = 4, 
                BanTime = new TimeSpan(1, 0, 0, 0),
                RemoveAllUsers = settings.RemoveAllUsers
            }).ToList();

            var user = users[attempts];

            {
                var result = new UnFollowUserEngine().Execute(driver, new UnFollowUserModel()
                {
                    UserLink = user
                });

                if (result)
                {
                    new RemoveUserCommandHandler(context).Handle(new RemoveUserCommand
                    {
                        UserLink = user
                    });

                    new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                    {
                        Note = "Success unfollowing users: " + user,
                        Name = FunctionalityName.UnfollowUsers,
                        WorkStatus = WorkStatus.Success
                    });
                }
                else
                {
                    if (attempts > 0)
                    {
                        UnfollowUsers(driver, context, attempts - 1);
                    }
                    else
                    {
                        new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                        {
                            Note = "Error unfollowing users: " + user,
                            Name = FunctionalityName.UnfollowUsers,
                            WorkStatus = WorkStatus.Cancelled
                        });
                    }
                }
            }
        }

        public void FollowUsers(RemoteWebDriver driver, DataBaseContext context)
        {
            FollowUsers(driver, context, 3);
        }

        public void AddBase(IStoreContext context, string link)
        {
            new MarkUserAsRequiredCommandHandler(context).Handle(new MarkUserAsRequiredCommand
            {
                UserLink = link
            });
        }

        public void FilterUser(string user, int index, int count, RemoteWebDriver driver, IStoreContext destinationContext, List<string> languages, int followersLimit, bool emptyAllowed, List<string> passWords, List<string> passNames, Action<int, int, string, bool, string> makeRecord)
        {
            try
            {
                var userInfo = new GetUserInfoEngine().Execute(driver, new GetUserInfoEngineModel
                {
                    UserLink = user
                });

                if (userInfo.FollowerCount == 0 && userInfo.FollowingCount == 0 && userInfo.PublicationCount == 0 && string.IsNullOrWhiteSpace(userInfo.Text))
                {
                    makeRecord(index, count, user, false, "exception");
                    return;
                }

                if (userInfo.PublicationCount == 0)
                {
                    makeRecord(index, count, user, false, "no publication");
                    return;
                }

                if (userInfo.PublicationCount == 0)
                {
                    makeRecord(index, count, user, false, "no followings");
                    return;
                }

                if (followersLimit < userInfo.FollowerCount)
                {
                    makeRecord(index, count, user, false, "followers");
                    return;
                }

                if (userInfo.IsStar)
                {
                    makeRecord(index, count, user, false, "star");
                    return;
                }

                if (!string.IsNullOrWhiteSpace(user) && (passNames.Any(s => user.ToUpper().Contains(s.ToUpper())) || passWords.Any(s => user.ToUpper().Contains(s.ToUpper()))))
                {
                    new MarkUserAsToFollowCommandHandler(destinationContext).Handle(new MarkUserAsToFollowCommand
                    {
                        UserLink = user
                    });
                    makeRecord(index, count, user, true, "there are pass url");
                    return;
                }

                if (string.IsNullOrWhiteSpace(userInfo.Text))
                {
                    if (!emptyAllowed)
                    {
                        makeRecord(index, count, user, false, "no text");
                        return;
                    }

                    new MarkUserAsToFollowCommandHandler(destinationContext).Handle(new MarkUserAsToFollowCommand
                    {
                        UserLink = user
                    });
                    makeRecord(index, count, user, true, "no text");
                    return;
                }

                if (!string.IsNullOrWhiteSpace(userInfo.Name) && (passNames.Any(s => userInfo.Name.ToUpper().Contains(s.ToUpper())) || passWords.Any(s => userInfo.Name.ToUpper().Contains(s.ToUpper()))))
                {
                    new MarkUserAsToFollowCommandHandler(destinationContext).Handle(new MarkUserAsToFollowCommand
                    {
                        UserLink = user
                    });
                    makeRecord(index, count, user, true, "there are pass names");
                    return;
                }
                
                if (userInfo.Text.Length < 3)
                {
                    if (!emptyAllowed)
                    {
                        makeRecord(index, count, user, false, "too small text to detect language");
                        return;
                    }

                    new MarkUserAsToFollowCommandHandler(destinationContext).Handle(new MarkUserAsToFollowCommand
                    {
                        UserLink = user
                    });
                    makeRecord(index, count, user, true, "too small text to detect language");
                    return;
                }

                if (passWords.Any(s => userInfo.Text.ToUpper().Contains(s.ToUpper())))
                {
                    new MarkUserAsToFollowCommandHandler(destinationContext).Handle(new MarkUserAsToFollowCommand
                    {
                        UserLink = user
                    });
                    makeRecord(index, count, user, true, "there are pass words");
                    return;
                }

                var language = new DetectLanguageEngine().Execute(driver, new DetectLanguageEngineModel
                {
                    Text = userInfo.Text
                });

                if (language != null && language.Language != null && !languages.Contains(language.Language))
                {
                    makeRecord(index, count, user, false, "incorrect language");
                    return;
                }

                new MarkUserAsToFollowCommandHandler(destinationContext).Handle(new MarkUserAsToFollowCommand
                {
                    UserLink = user
                });
                makeRecord(index, count, user, true, "correct language");
            }
            catch (Exception exception)
            {
                makeRecord(index, count, user, false, "exception");
                return;
            }
        }

        public void FilterUsers(RemoteWebDriver driver, IStoreContext sourceContext, IStoreContext destinationContext, List<string> languages, int followersLimit, bool emptyAllowed, List<string> passWords, List<string> passNames, Action<int, int, string, bool, string> makeRecord)
        {
            new RemoveAllUsersByStatusCommandHandler(destinationContext).Handle(new RemoveAllUsersByStatusCommand
            {
                UserStatus = UserStatus.ToFollow
            });

            var users = new GetAllKnownUsersQueryHandler(sourceContext).Handle(new GetAllKnownUsersQuery());

            var index = 0;
            var count = users.Count;

            //foreach (var user in users)
            while (index < count)
            {
                Thread.Sleep(100);

                var user = users[index];
                index++;
                FilterUser(user, index, count, driver, destinationContext, languages, followersLimit, emptyAllowed, passWords, passNames, makeRecord);
            }
        }

        public void FollowUsers(RemoteWebDriver driver, DataBaseContext context, int attempts)
        {
            if (attempts == 3)
            {
                new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                {
                    Note = "Start following users",
                    Name = FunctionalityName.FollowUsers,
                    WorkStatus = WorkStatus.Started
                });

                Registration(driver, context);

                var settings = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());

                var mainUserInfo = new GetUserInfoEngine().Execute(driver, new GetUserInfoEngineModel
                {
                    UserLink = settings.HomePageUrl
                });

                if (mainUserInfo.FollowingCount > settings.MaxUsersToFollowCount)
                {
                    new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                    {
                        Note = "Error following users",
                        Name = FunctionalityName.FollowUsers,
                        WorkStatus = WorkStatus.Cancelled
                    });

                    return;
                }
            }

            var users = new GetUsersToFollowQueryHandler(context).Handle(new GetUsersToFollowQuery { MaxCount = 4 }).ToList();

            var user = users[attempts];
            
            {
                var userInfo = new GetUserInfoEngine().Execute(driver, new GetUserInfoEngineModel
                {
                    UserLink = user
                });

                if (userInfo.FollowerCount < 3000 && userInfo.FollowingCount > 6800)
                {
                    var register = new ReesterStoreContext(); //Reester
                    new AddUserToRegisterCommandHandler(register).Handle(new AddUserToRegisterCommand
                    {
                        Link = user
                    });
                }

                bool result;

                if (userInfo.IsStar)
                {
                    result = new FollowUserEngine().Execute(driver, new FollowUserModel
                    {
                        UserLink = user
                    });

                    if (result)
                    {
                        new MarkUserAsStarCommandHandler(context).Handle(new MarkUserAsStarCommand
                        {
                            UserLink = user
                        });
                        
                        new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                        {
                            Note = "Success following users: " + user,
                            Name = FunctionalityName.FollowUsers,
                            WorkStatus = WorkStatus.Success
                        });
                    }
                    else
                    {
                        if (attempts > 0)
                        {
                            FollowUsers(driver, context, attempts - 1);
                        }
                        else
                        {
                            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                            {
                                Note = "Error following users: " + user,
                                Name = FunctionalityName.FollowUsers,
                                WorkStatus = WorkStatus.Cancelled
                            });
                        }
                    }

                    return;
                }

                var access = new CheckFeaturesAccessQueryHandler(context).Handle(new CheckFeaturesAccessQuery()
                {
                    FeaturesName = FeaturesName.CheckSpammers
                });

                if ((access && UserIsSpammer(driver, context, userInfo)) || UserIsForeign(driver, context, userInfo))
                {
                    new MarkUserAsToDeleteCommandHandler(context).Handle(new MarkUserAsToDeleteCommand
                    {
                        UserLink = user
                    });

                    if (attempts > 0)
                    {
                        FollowUsers(driver, context, attempts - 1);
                    }
                    else
                    {
                        new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                        {
                            Note = "Error following users: " + user,
                            Name = FunctionalityName.FollowUsers,
                            WorkStatus = WorkStatus.Cancelled
                        });
                    }

                    return;
                }

                result = new FollowUserEngine().Execute(driver, new FollowUserModel
                {
                    UserLink = user
                });

                if (result)
                {
                    new MarkUserAsNormalCommandHandler(context).Handle(new MarkUserAsNormalCommand
                    {
                        UserLink = user
                    });

                    new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                    {
                        Note = "Success following users: " + user,
                        Name = FunctionalityName.FollowUsers,
                        WorkStatus = WorkStatus.Success
                    });
                }
                else
                {
                    if (attempts > 0)
                    {
                        FollowUsers(driver, context, attempts - 1);
                    }
                    else
                    {
                        new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                        {
                            Note = "Error following users: " + user,
                            Name = FunctionalityName.FollowUsers,
                            WorkStatus = WorkStatus.Cancelled
                        });
                    }
                }
            }
        }

        public void RunBackgroundSearchingNewUsers(IStoreContext context, RemoteWebDriver spyDriver, DataBaseContext spyContext, Action<int> showProcess = null, bool followings = true, bool followers = true)
        {
            var users = new GetUsersNotCheckedForFriendsQueryHandler(context).Handle(new GetUsersNotCheckedForFriendsQuery { MaxCount = int.MaxValue });

            if (!users.Any())
            {
                return;
            }
            
            Registration(spyDriver, spyContext);

            var results = new List<string>();

            foreach (var user in users)
            {
                var extraUserInfo = new GetUserIdEngine().Execute(spyDriver, new GetUserIdEngineModel
                {
                    UserLink = user
                });

                if (followings)
                {
                    results.AddRange(new SearchUserFollowingsEngine().Execute(spyDriver, new SearchUserFollowingsModel
                    {
                        UserLink = user,
                        UserName = extraUserInfo.UserName,
                        Id = extraUserInfo.Id,
                        ShowProcess = showProcess
                    }));
                }

                if (followers)
                {
                    results.AddRange(new SearchUserFollowersEngine().Execute(spyDriver, new SearchUserFollowersModel
                    {
                        UserLink = user,
                        UserName = extraUserInfo.UserName,
                        Id = extraUserInfo.Id,
                        ShowProcess = showProcess
                    }));
                }
            }

            var knownUsers = new GetAllKnownUsersQueryHandler(context).Handle(new GetAllKnownUsersQuery());

            var usersToMark = results.Except(knownUsers).ToList();

            new MarkUsersAsToFollowCommandHandler(context).Handle(new MarkUsersAsToFollowCommand
            {
                Users = usersToMark
            });

            foreach (var user in users)
            {
                new MarkUserAsCheckedForFriendsCommandHandler(context).Handle(new MarkUserAsCheckedForFriendsCommand
                {
                    User = user
                });
            }
        }

        public void RunBackgroundSearchingNewStars(DataBaseContext context, RemoteWebDriver spyDriver, DataBaseContext spyContext, List<string> users, Action<int> showProcess = null, bool followings = true, bool followers = false)
        {
            //take risk of skipping bugs
            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Success searching new stars",
                Name = FunctionalityName.SearchNewUsers,
                WorkStatus = WorkStatus.Success
            });

            if (!users.Any())
            {
                new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                {
                    Note = "Stop searching new stars",
                    Name = FunctionalityName.SearchNewUsers,
                    WorkStatus = WorkStatus.Cancelled
                });
                return;
            }

            Registration(spyDriver, spyContext);

            var results = new List<string>();

            foreach (var user in users)
            {
                var extraUserInfo = new GetUserIdEngine().Execute(spyDriver, new GetUserIdEngineModel
                {
                    UserLink = user
                });

                if (followings)
                {
                    results.AddRange(new SearchUserFollowingsEngine().Execute(spyDriver, new SearchUserFollowingsModel
                    {
                        UserLink = user,
                        UserName = extraUserInfo.UserName,
                        Id = extraUserInfo.Id,
                        ShowProcess = showProcess
                    }));
                }

                if (followers)
                {
                    results.AddRange(new SearchUserFollowersEngine().Execute(spyDriver, new SearchUserFollowersModel
                    {
                        UserLink = user,
                        UserName = extraUserInfo.UserName,
                        Id = extraUserInfo.Id,
                        ShowProcess = showProcess
                    }));
                }
            }

            new AddStarsCommandHandler(context).Handle(new AddStarsCommand
            {
                StarsUrls = results
            });

            foreach (var user in users)
            {
                new MarkUserAsCheckedForFriendsCommandHandler(context).Handle(new MarkUserAsCheckedForFriendsCommand
                {
                    User = user
                });
            }
        }

        public void SearchNewUsers(RemoteWebDriver driver, DataBaseContext context)
        {
            /*new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Start searching new users",
                Name = FunctionalityName.SearchNewUsers,
                WorkStatus = WorkStatus.Started
            });

            Registration(driver, context);

            Task.Factory.StartNew(() => RunBackgroundSearchingNewUsers(context.OpenCopyContext()),
                      CancellationToken.None,
                      TaskCreationOptions.None,
                      TaskScheduler.Default);*/
        }

        public void RunBackgroundSearchingUslessUsers(DataBaseContext context, RemoteWebDriver spyDriver, DataBaseContext spyContext, Action<int> showProcess = null)
        {
            //take risk of skipping bugs
            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Success searching useless users",
                Name = FunctionalityName.SearchUselessUsers,
                WorkStatus = WorkStatus.Success
            });

            Registration(spyDriver, spyContext);

            var settings = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());

            var followers = new SearchUserFollowersEngine().Execute(spyDriver, new SearchUserFollowersModel
            {
                UserLink = settings.HomePageUrl,
                UserName = settings.Login,
                Id = settings.InstagramtId.ToString(),
                ShowProcess = showProcess
            });

            var followings = new SearchUserFollowingsEngine().Execute(spyDriver, new SearchUserFollowingsModel
            {
                UserLink = settings.HomePageUrl,
                UserName = settings.Login,
                Id = settings.InstagramtId.ToString(),
                ShowProcess = showProcess
            });

            if (followings == null || !followings.Any() || followers == null || !followers.Any())
            {
                return;
            }

            var usersToClear = followings.Except(followers).ToList();
            var normalUsers = followers.Intersect(followings).ToList();

            new RemoveAllUsersByStatusCommandHandler(context).Handle(new RemoveAllUsersByStatusCommand { UserStatus = UserStatus.Normal });

            new MarkUsersAsToDeleteCommandHandler(context).Handle(new MarkUsersAsToDeleteCommand
            {
                UsersToClear = usersToClear,
                NormalUsers = normalUsers
            });
        }

        public void SearchUselessUsers(RemoteWebDriver driver, DataBaseContext context)
        {
            /*new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Start searching useless users",
                Name = FunctionalityName.SearchUselessUsers,
                WorkStatus = WorkStatus.Started
            });

            Registration(driver, context);

            Task.Factory.StartNew(() => RunBackgroundSearchingUslessUsers(context.OpenCopyContext()),
                      CancellationToken.None,
                      TaskCreationOptions.None,
                      TaskScheduler.Default);*/
        }

        public void SaveMediaByHashTag(RemoteWebDriver driver, DataBaseContext context)
        {
            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Start saving media by hash tag",
                Name = FunctionalityName.SaveMediaByHashTag,
                WorkStatus = WorkStatus.Started
            });

            Registration(driver, context);

            var count = new GetMediaToLikeCountQueryHandler(context).Handle(new GetMediaToLikeCountQuery());

            if (count > 10000)
            {
                new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                {
                    Note = "Stop saving media by hash tag",
                    Name = FunctionalityName.SaveMediaByHashTag,
                    WorkStatus = WorkStatus.Cancelled
                });
                return;
            }

            var hasTags = new GetHashTagsQueryHandler(context).Handle(new GetHashTagsQuery());

            foreach (var hasTag in hasTags)
            {
                try
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

                    new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                    {
                        Note = "Success saving media by hash tag: " + hasTag,
                        Name = FunctionalityName.SaveMediaByHashTag,
                        WorkStatus = WorkStatus.Success
                    });
                }
                catch (Exception)
                {
                    new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                    {
                        Note = "Error saving media by hash tag: " + hasTag,
                        Name = FunctionalityName.SaveMediaByHashTag,
                        WorkStatus = WorkStatus.Cancelled
                    });
                }
            }   
        }

        public void SaveMediaByHomePage(RemoteWebDriver driver, DataBaseContext context)
        {
            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Start saving media by home page",
                Name = FunctionalityName.SaveMediaByHomePage,
                WorkStatus = WorkStatus.Started
            });

            Registration(driver, context);

            var count = new GetMediaToLikeCountQueryHandler(context).Handle(new GetMediaToLikeCountQuery());

            if (count > 3000)
            {
                new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                {
                    Note = "Stop saving media by home page",
                    Name = FunctionalityName.SaveMediaByHomePage,
                    WorkStatus = WorkStatus.Cancelled
                });
                return;
            }

            var mediaList = new GetMediaByMainPageEngine().Execute(driver, new GetMediaByMainPageModel()
            {
                CountMedia = 30
            });

            new AddMediaListCommandHandler(context).Handle(new AddMediaListCommand
            {
                MediaList = mediaList,
                MediaStatus = MediaStatus.ToLike
            });

            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Success saving media by home page",
                Name = FunctionalityName.SaveMediaByHomePage,
                WorkStatus = WorkStatus.Success
            });
        }

        public void LikeMedias(RemoteWebDriver driver, ISettingsContext context, List<string> medias)
        {
            Registration(driver, context);

            foreach (var media in medias)
            {
                new LikeMediaEngine().Execute(driver, new LikeMediaModel
                {
                    Link = media
                });

                Thread.Sleep(1500);
            }
        }

        public void LikeMedias(RemoteWebDriver driver, DataBaseContext context)
        {
            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Start liking media",
                Name = FunctionalityName.LikeMedias,
                WorkStatus = WorkStatus.Started
            });

            Registration(driver, context);

            var medias = new GetMediaToLikeQueryHandler(context).Handle(new GetMediaToLikeQuery
            {
                MaxCount = 1
            });

            foreach (var media in medias)
            {
                var userLink = new LikeMediaEngine().Execute(driver, new LikeMediaModel
                {
                    Link = media
                });

                new MarkMediaAsLikedCommandHandler(context).Handle(new MarkMediaAsLikedCommand
                {
                    Link = media
                });

                if (!string.IsNullOrEmpty(userLink.UserLink))
                {
                    new MarkUserAsToFollowCommandHandler(context).Handle(new MarkUserAsToFollowCommand
                    {
                        UserLink = userLink.UserLink
                    });
                }

                new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                {
                    Note = "Success liking media: " + media,
                    Name = FunctionalityName.LikeMedias,
                    WorkStatus = WorkStatus.Success
                });
            }
        }

        public void ClearOldMedia(RemoteWebDriver driver, DataBaseContext context)
        {
            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Start clearing old media",
                Name = FunctionalityName.ClearOldMedia,
                WorkStatus = WorkStatus.Started
            });

            Registration(driver, context);

            new DeleteMediaCommandHandler(context).Handle(new DeleteMediaCommand
            {
                UrlList = new GetMediaToDeleteQueryHandler(context).Handle(new GetMediaToDeleteQuery())
            });

            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Success clearing old media",
                Name = FunctionalityName.ClearOldMedia,
                WorkStatus = WorkStatus.Success
            });
        }
        
        public void AddComments(RemoteWebDriver driver, DataBaseContext context)
        {
            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Start adding comments",
                Name = FunctionalityName.AddComments,
                WorkStatus = WorkStatus.Started
            });

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
                        CommentText =
                            "Всем привет! Старые методы накрутки подписчиков ушли в прошлое! Только \"живая\" целевая аудитория! Подробности в профиле!",
                        Link = media
                    });

                    new MarkMediaAsHavingCommentCommandHandler(context).Handle(new MarkMediaAsHavingCommentCommand()
                    {
                        Link = media
                    });

                    new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                    {
                        Note = "Success adding comments: " + media,
                        Name = FunctionalityName.AddComments,
                        WorkStatus = WorkStatus.Success
                    });
                }
            }
            else
            {
                new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                {
                    Note = "Stop adding comments",
                    Name = FunctionalityName.AddComments,
                    WorkStatus = WorkStatus.Cancelled
                });
            }
        }

        public void AddActivityHistoryMark(RemoteWebDriver driver, DataBaseContext context)
        {
            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Start adding notes",
                Name = FunctionalityName.AddActivityHistoryMark,
                WorkStatus = WorkStatus.Started
            });

            Registration(driver, context);

            var settings = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());

            var userInfo = new GetUserInfoEngine().Execute(driver, new GetUserInfoEngineModel
            {
                UserLink = settings.HomePageUrl
            });

            if (userInfo.FollowerCount == 0 || userInfo.FollowingCount == 0)
            {
                new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                {
                    Note = "Error adding notes",
                    Name = FunctionalityName.AddActivityHistoryMark,
                    WorkStatus = WorkStatus.Cancelled
                });
                return;
            }

            new AddFollowersNoteCommandHandler(context).Handle(new AddFollowersNoteCommand
            {
                FollowersCount = userInfo.FollowerCount,
                MediaCount = userInfo.PublicationCount,
                FollowingsCount = userInfo.FollowingCount
            });

            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Success adding notes",
                Name = FunctionalityName.AddActivityHistoryMark,
                WorkStatus = WorkStatus.Success
            });

            new MakeFunctionalityReportCommandHandler(context).Handle(new MakeFunctionalityReportCommand());
        }

        public void HandleCaptchaException(RemoteWebDriver driver, DataBaseContext context)
        {
            Registration(driver, context);

            var testLink = new GetRequiredUsersQueryHandler(context).Handle(new GetRequiredUsersQuery { MaxCount = 1 }).FirstOrDefault();

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

            if (!languages.Any())
            {
                return false;
            }

            var language = new DetectLanguageEngine().Execute(driver, new DetectLanguageEngineModel
            {
                Text = userInfo.Text
            });

            if (language == null || language.Language == null)
            {
                return false;
            }

            var containsLanguage = languages.Any(s => string.Equals(s, language.Language, StringComparison.CurrentCultureIgnoreCase));

            return !containsLanguage;
        }
    }
}
