using System;
using System.Collections.Generic;
using System.Linq;
using DataBase.Contexts;
using DataBase.QueriesAndCommands;
using Engines.Engines.FollowUserEngine;
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
                new FollowUserEngine().Execute(driver, new FollowUserModel()
                {
                    UserLink = user
                });

                new MarkUserAsFollowingCommandHandler(context).Handle(new MarkUserAsFollowingCommand
                {
                    User = user
                });
            }
        }

        public void SearchNewUsers(RemoteWebDriver driver, DataBaseContext context)
        {
            Registration(driver, context);

            List<string> users = new GetUsersNotCheckedForFriendsQueryHandler(context).Handle(new GetUsersNotCheckedForFriendsQuery { MaxCount = 1 });

            List<string> results = new List<string>();

            foreach (var user in users)
            {
                results.AddRange(new SearchUserFriendsEngine().Execute(driver, new SearchUserFriendsModel
                {
                    UserPageLink = user,
                    MaxCount = 100
                }));
                results.AddRange(new SearchUserUnAddedFriendsEngine().Execute(driver, new SearchUserUnAddedFriendsModel
                {
                    UserPageLink = user,
                    MaxCount = 100
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

        public void ApproveUsers(RemoteWebDriver driver, DataBaseContext context)
        {
            Registration(driver, context);

            var settings = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());

            var addedUsers = new SearchUserFriendsEngine().Execute(driver, new SearchUserFriendsModel
            {
                UserPageLink = settings.HomePageUrl,
                MaxCount = null
            });

            var addedToBaseUsers = new GetAddedUsersQueryHandler(context).Handle(new GetAddedUsersQuery());


            var usersToAdd = addedUsers.Except(addedToBaseUsers).ToList();

            foreach (var user in usersToAdd)
            {
                new FollowUserEngine().Execute(driver, new FollowUserModel
                {
                    UserLink = user
                });
                new MarkUserAsAddedCommandHandler(context).Handle(new MarkUserAsAddedCommand
                {
                    User = user
                });
            }
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
    }
}
