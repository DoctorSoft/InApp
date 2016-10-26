
using System;
using System.Collections.Generic;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Commands.Functionality;
using DataBase.QueriesAndCommands.Commands.History;
using DataBase.QueriesAndCommands.Commands.Media;
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
using Engines.Engines.WaitingCaptchEngine;
using NTextCat;
using OpenQA.Selenium.Remote;

namespace InstagramApp
{
    public class InstagramService
    {
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
            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Start unfollowing users",
                Name = FunctionalityName.UnfollowUsers,
                WorkStatus = WorkStatus.Started
            });

            Registration(driver, context);

            var settings = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());

            var userInfo = new GetUserInfoEngine().Execute(driver, new GetUserInfoEngineModel
            {
                UserLink = settings.HomePageUrl
            });

            // todo: move to settings
            if (userInfo.FollowingCount < 1000)
            {
                new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                {
                    Note = "Stop unfollowing users",
                    Name = FunctionalityName.UnfollowUsers,
                    WorkStatus = WorkStatus.Calcelled
                });

                return;
            }

            var users = new GetUsersToDeleteQueryHandler(context).Handle(new GetUsersToDeleteQuery { MaxCount = 1, BanTime = new TimeSpan(1, 0, 0, 0)});

            foreach (var user in users)
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
                    new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                    {
                        Note = "Error unfollowing users: " + user,
                        Name = FunctionalityName.UnfollowUsers,
                        WorkStatus = WorkStatus.Calcelled
                    });
                }
            }
        }

        public void FollowUsers(RemoteWebDriver driver, DataBaseContext context)
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

            // todo: move to settings
            if (mainUserInfo.FollowingCount > 6000)
            {
                return;
            }

            var users = new GetUsersToFollowQueryHandler(context).Handle(new GetUsersToFollowQuery { MaxCount = 1 });

            foreach (var user in users)
            {
                var userInfo = new GetUserInfoEngine().Execute(driver, new GetUserInfoEngineModel
                {
                    UserLink = user
                });

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
                        new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                        {
                            Note = "Error following users: " + user,
                            Name = FunctionalityName.FollowUsers,
                            WorkStatus = WorkStatus.Calcelled
                        });
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

                    new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                    {
                        Note = "Error following users: " + user,
                        Name = FunctionalityName.FollowUsers,
                        WorkStatus = WorkStatus.Calcelled
                    });

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
                    new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                    {
                        Note = "Error following users: " + user,
                        Name = FunctionalityName.FollowUsers,
                        WorkStatus = WorkStatus.Calcelled
                    });
                }
            }
        }

        public void SearchNewUsers(RemoteWebDriver driver, DataBaseContext context)
        {
            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Start searching new users",
                Name = FunctionalityName.SearchNewUsers,
                WorkStatus = WorkStatus.Started
            });

            Registration(driver, context);

            var count = new GetUsersToFollowCountQueryHandler(context).Handle(new GetUsersToFollowCountQuery());

            if (count > 3000)
            {
                new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                {
                    Note = "Stop searching new users",
                    Name = FunctionalityName.SearchNewUsers,
                    WorkStatus = WorkStatus.Calcelled
                });
                return;
            }

            var users = new GetUsersNotCheckedForFriendsQueryHandler(context).Handle(new GetUsersNotCheckedForFriendsQuery { MaxCount = 1 });

            var results = new List<string>();

            foreach (var user in users)
            {
                var extraUserInfo = new GetUserIdEngine().Execute(driver, new GetUserIdEngineModel
                {
                    UserLink = user
                });

                results.AddRange(new SearchUserFollowingsEngine().Execute(driver, new SearchUserFollowingsModel
                {
                    UserLink = user,
                    UserName = extraUserInfo.UserName,
                    Id = extraUserInfo.Id
                }));

                results.AddRange(new SearchUserFollowersEngine().Execute(driver, new SearchUserFollowersModel
                {
                    UserLink = user,
                    UserName = extraUserInfo.UserName,
                    Id = extraUserInfo.Id
                }));
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

            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Success searching new users",
                Name = FunctionalityName.SearchNewUsers,
                WorkStatus = WorkStatus.Success
            });
        }

        public void SearchUselessUsers(RemoteWebDriver driver, DataBaseContext context)
        {
            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Start searching useless users",
                Name = FunctionalityName.SearchUselessUsers,
                WorkStatus = WorkStatus.Started
            });

            Registration(driver, context);

            var settings = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());

            var userInfo = new GetUserIdEngine().Execute(driver, new GetUserIdEngineModel
            {
                UserLink = settings.HomePageUrl
            });

            var followers =new SearchUserFollowersEngine().Execute(driver, new SearchUserFollowersModel
            {
                UserLink = settings.HomePageUrl,
                UserName = userInfo.UserName,
                Id = userInfo.Id
            });

            var followings = new SearchUserFollowingsEngine().Execute(driver, new SearchUserFollowingsModel
            {
                UserLink = settings.HomePageUrl,
                UserName = userInfo.UserName,
                Id = userInfo.Id
            });

            if (followings == null || !followings.Any() || followers == null || !followers.Any())
            {
                return;
            } 

            var usersToClear = followings.Except(followers).ToList();

            new MarkUsersAsToDeleteCommandHandler(context).Handle(new MarkUsersAsToDeleteCommand
            {
                Users = usersToClear
            });

            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Success searching useless users",
                Name = FunctionalityName.SearchUselessUsers,
                WorkStatus = WorkStatus.Success
            });
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

            if (count > 3000)
            {
                new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                {
                    Note = "Stop saving media by hash tag",
                    Name = FunctionalityName.SaveMediaByHashTag,
                    WorkStatus = WorkStatus.Calcelled
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
                        WorkStatus = WorkStatus.Calcelled
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
                    WorkStatus = WorkStatus.Calcelled
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
                    WorkStatus = WorkStatus.Calcelled
                });
            }
        }

        public void AddFollowersNote(RemoteWebDriver driver, DataBaseContext context)
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
                    WorkStatus = WorkStatus.Calcelled
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
