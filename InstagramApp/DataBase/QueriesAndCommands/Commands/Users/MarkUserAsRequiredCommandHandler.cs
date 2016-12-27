using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsRequiredCommandHandler : ICommandHandler<MarkUserAsRequiredCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public MarkUserAsRequiredCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(MarkUserAsRequiredCommand command)
        {
            var user = context.Users.FirstOrDefault(model => model.Link == command.UserLink);

            if (user == null)
            {
                user = new UserDbModel
                {
                    Link = command.UserLink,
                    UserStatus = UserStatus.Required,
                    FriendsWereSearched = false
                };
            }
            else
            {
                user.UserStatus = UserStatus.Required;
                user.FriendsWereSearched = false;
            }

            context.Users.AddOrUpdate(user);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
