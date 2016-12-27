using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsImportantCommandHandler : ICommandHandler<MarkUserAsImportantCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public MarkUserAsImportantCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(MarkUserAsImportantCommand command)
        {
            var user = context.Users.FirstOrDefault(model => model.Link == command.UserLink);

            if (user == null)
            {
                user = new UserDbModel
                {
                    Link = command.UserLink,
                    UserStatus = UserStatus.ImportantForOwner
                };
            }
            else
            {
                user.UserStatus = UserStatus.ImportantForOwner;
            }

            context.Users.AddOrUpdate(user);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
