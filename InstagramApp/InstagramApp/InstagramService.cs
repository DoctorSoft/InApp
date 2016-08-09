using System.Collections.Generic;
using System.Linq;
using DataBase.Contexts;
using DataBase.QueriesAndCommands;
using Engines.Engines.FollowUserEngine;
using Engines.Engines.RegistrationEngine;
using Engines.Engines.SearchUserFriendsEngine;
using OpenQA.Selenium.Remote;

namespace InstagramApp
{
    public class InstagramService
    {
        const string UserName = "mydevpage";
        const string Password = "Ntvyjnf123";

        private void Registration(RemoteWebDriver driver)
        {
            new RegistrationEngine().Execute(driver, new RegistrationModel
            {
                UserName = UserName,
                Password = Password
            });
        }

        public void UnfollowUsers(RemoteWebDriver driver)
        {
            Registration(driver);

            var users = new GetUsersToUnFollowQueryHandler(new DataBaseContext()).Handle(new GetUsersToUnFollowQuery { MaxCount = 10 });

            foreach (var user in users)
            {
                new UnFollowUserEngine().Execute(driver, new UnFollowUserModel()
                {
                    UserLink = user
                });

                new MarkUserAsBannedCommandHandler(new DataBaseContext()).Handle(new MarkUserAsBannedCommand
                {
                    User = user
                });
            }
        }

        public void FollowUsers(RemoteWebDriver driver)
        {
            Registration(driver);

            var users = new GetUsersToFollowQueryHandler(new DataBaseContext()).Handle(new GetUsersToFollowQuery { MaxCount = 10 });

            foreach (var user in users)
            {
                new FollowUserEngine().Execute(driver, new FollowUserModel()
                {
                    UserLink = user
                });

                new MarkUserAsFollowingCommandHandler(new DataBaseContext()).Handle(new MarkUserAsFollowingCommand
                {
                    User = user
                });
            }
        }

        public void FollowNewUsers(RemoteWebDriver driver)
        {
            List<string> users = new List<string>();

            List<string> results = new List<string>();

            foreach (var user in users)
            {
                results.AddRange(new SearchUserFriendsEngine().Execute(driver, new SearchUserFriendsModel
                {
                    UserPageLink = user
                }));
                results.AddRange(new SearchUserUnAddedFriendsEngine().Execute(driver, new SearchUserUnAddedFriendsModel
                {
                    UserPageLink = user
                }));
            }

            var addUserListCommand = new AddUserListCommand
            {
                Users = results
            };
            new AddUserListCommandHandler(new DataBaseContext()).Handle(addUserListCommand);
        }

        public void ApproveUsers(RemoteWebDriver driver)
        {
            Registration(driver);

            var addedUsers = new SearchUserFriendsEngine().Execute(driver, new SearchUserFriendsModel
            {
                UserPageLink = "https://www.instagram.com/mydevpage/"
            });

            var addedToBaseUsers = new GetAddedUsersQueryHandler(new DataBaseContext()).Handle(new GetAddedUsersQuery());

            var usersToAdd = addedUsers.Except(addedToBaseUsers).ToList();

            foreach (var user in usersToAdd)
            {
                new FollowUserEngine().Execute(driver, new FollowUserModel
                {
                    UserLink = user
                });
                new MarkUserAsAddedCommandHandler(new DataBaseContext()).Handle(new MarkUserAsAddedCommand
                {
                    User = user
                });
            }
        }
    }
}
