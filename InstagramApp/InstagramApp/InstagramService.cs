﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataBase.Contexts;
using DataBase.QueriesAndCommands;
using DataBase.QueriesAndCommands.Commands.Media;
using DataBase.QueriesAndCommands.Commands.Settings;
using DataBase.QueriesAndCommands.Commands.Users;
using DataBase.QueriesAndCommands.Queries.Languages;
using DataBase.QueriesAndCommands.Queries.Media;
using DataBase.QueriesAndCommands.Queries.Settings;
using DataBase.QueriesAndCommands.Queries.Users;
using DataBase.QueriesAndCommands.Queries.Words;
using Engines.Engines.FollowUserEngine;
using Engines.Engines.GetUserInfoEngine;
using Engines.Engines.LikeHashTagEngine;
using Engines.Engines.RegistrationEngine;
using Engines.Engines.SearchUserFriendsEngine;
using Engines.Engines.WaitingCaptchEngine;
using OpenQA.Selenium.Remote;

namespace InstagramApp
{
    public class InstagramService
    {
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

            var users = new GetUsersToUnFollowQueryHandler(context).Handle(new GetUsersToUnFollowQuery { MaxCount = 100, BanTime = new TimeSpan(5, 0, 0, 0)});

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

            List<string> users = new GetUsersNotCheckedForFriendsQueryHandler(context).Handle(new GetUsersNotCheckedForFriendsQuery { MaxCount = 1 });

            List<string> results = new List<string>();

            foreach (var user in users)
            {
                var userInfo = new GetUserInfoEngine().Execute(driver, new GetUserInfoEngineModel
                {
                    UserLink = user
                });

                results.AddRange(new SearchUserFriendsEngine().Execute(driver, new SearchUserFriendsModel
                {
                    UserPageLink = user,
                    MaxCount = 100,
                    Count = userInfo.FollowerCount
                }));

                results.AddRange(new SearchUserUnAddedFriendsEngine().Execute(driver, new SearchUserUnAddedFriendsModel
                {
                    UserPageLink = user,
                    MaxCount = 100,
                    Count = userInfo.FollowingCount
                }));
            }

            var addUserListCommand = new AddUserListCommand
            {
                Users = results
            };

            new AddUserListCommandHandler(context).Handle(addUserListCommand);

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

            var addedUsers = new SearchUserFriendsEngine().Execute(driver, new SearchUserFriendsModel
            {
                UserPageLink = settings.HomePageUrl,
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
                UserPageLink = settings.HomePageUrl,
                MaxCount = null,
                Count = userInfo.FollowingCount
            });

            var basedFollowings = new GetFollowingUsersQueryHandler(context).Handle(new GetFollowingUsersQuery());

            var toFollowUsers = followings.Except(basedFollowings).ToList();

            new AddUserListCommandHandler(context).Handle(new AddUserListCommand
            {
                Users = toFollowUsers
            });
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

            if (UserIsSpammer(driver, context, userInfo))
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

        public void LikeHashTag(RemoteWebDriver driver, DataBaseContext context)
        {
            Registration(driver, context);

            new AddMediaListCommandHandler(context).Handle(new AddMediaListCommand
            {
                MediaList = new LikeHashTagEngine().Execute(driver, new LikeHashTagModel()
                {
                    HashTag = "Grodno",
                    CountMedia = 20
                })
            });    
        }

        public void ClearOldMedia(RemoteWebDriver driver, DataBaseContext context)
        {
            Registration(driver, context);

            new DeleteMediaCommandHandler(context).Handle(new DeleteMediaCommand
            {
                UrlList = new GetMediaToDeleteQueryHandler(context).Handle(new GetMediaToDeleteQuery())
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
            const int MaxFollowingCount = 500;
            const double ExtraFollowingPenalty = 0.001;
            const int MaxFollowerCount = 500;
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
