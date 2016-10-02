using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsNormalCommandHandler : IVoidCommandHandler<MarkUserAsNormalCommand>
    {
        private readonly DataBaseContext context;

        public MarkUserAsNormalCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(MarkUserAsNormalCommand command)
        {
            var user = context.Users.FirstOrDefault(model => model.Link == command.UserLink);

            if (user == null)
            {
                user = new UserDbModel
                {
                    Link = command.UserLink,
                    UserStatus = UserStatus.Normal,
                    IncludingTime = DateTime.Now
                };

            }
            else
            {
                user.UserStatus = UserStatus.Normal;   
            }

            context.Users.AddOrUpdate(user);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
