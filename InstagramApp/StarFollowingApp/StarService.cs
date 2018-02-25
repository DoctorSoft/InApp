using Constants;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Commands.Functionality;
using DataBase.QueriesAndCommands.Commands.Stars;
using DataBase.QueriesAndCommands.Queries.Stars;
using Engines.Engines.FollowUserEngine;
using InstagramApp;
using OpenQA.Selenium.Remote;

namespace StarFollowingApp
{
    public class StarService
    {
        public void FollowStar(RemoteWebDriver driver, DataBaseContext context)
        {
            var instagramService = new InstagramService();

            instagramService.Registration(driver, context);

            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Start following users",
                Name = FunctionalityName.FollowUsers,
                WorkStatus = WorkStatus.Started
            });

            var users = new GetStarsQueryHandler(context).Handle(new GetStarsQuery {MaxCount = 1, ToFollow = true}); 


            foreach (var user in users)
            {
                var result = new FollowUserEngine().Execute(driver, new FollowUserModel
                {
                    UserLink = user
                });

                new MarkStarAsFollowedCommandHandler(context).Handle(new MarkStarAsFollowedCommand
                {
                    Link = user
                });

                if (result == true)
                {
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
                        WorkStatus = WorkStatus.Cancelled
                    });
                }
            }
        }

        public void UnfollowStar(RemoteWebDriver driver, DataBaseContext context)
        {
            var instagramService = new InstagramService();

            instagramService.Registration(driver, context);

            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
            {
                Note = "Start unfollowing users",
                Name = FunctionalityName.UnfollowUsers,
                WorkStatus = WorkStatus.Started
            });

            var users = new GetStarsQueryHandler(context).Handle(new GetStarsQuery { MaxCount = 1, ToFollow = false });

            foreach (var user in users)
            {
                var result = new UnFollowUserEngine().Execute(driver, new UnFollowUserModel
                {
                    UserLink = user
                });

                new MarkStarAsUnfollowedCommandHandler(context).Handle(new MarkStarAsUnfollowedCommand
                {
                    Link = user
                });

                if (result)
                {
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
                        WorkStatus = WorkStatus.Cancelled
                    });
                }
            }
        }
    }
}
