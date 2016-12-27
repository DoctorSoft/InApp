using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsToDeleteCommandHandler : ICommandHandler<MarkUserAsToDeleteCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public MarkUserAsToDeleteCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(MarkUserAsToDeleteCommand command)
        {
            var user = context.Users.FirstOrDefault(model => model.Link == command.UserLink);

            if (user == null)
            {
                user = new UserDbModel
                {
                    Link = command.UserLink,
                    UserStatus = UserStatus.ToDelete,
                    IncludingTime = DateTime.Now
                };

            }
            else
            {
                if (user.UserStatus != UserStatus.Star && user.UserStatus != UserStatus.Required && user.UserStatus != UserStatus.ImportantForOwner)
                {
                    user.UserStatus = UserStatus.ToDelete;
                }
                else
                {
                    return new VoidCommandResponse();
                }
            }

            context.Users.AddOrUpdate(user);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
