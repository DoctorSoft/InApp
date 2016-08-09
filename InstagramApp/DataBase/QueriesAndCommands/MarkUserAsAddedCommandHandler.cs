using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class MarkUserAsAddedCommandHandler : IVoidCommandHandler<MarkUserAsAddedCommand>
    {
        private readonly DataBaseContext context;

        public MarkUserAsAddedCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(MarkUserAsAddedCommand command)
        {
            var user = context.Users.FirstOrDefault(model => model.Link == command.User);

            if (user == null)
            {
                user = new UserDbModel
                {
                    Link = command.User,
                    UserStatus = UserStatus.Added,
                    IncludingTime = DateTime.Now
                };

            }
            else
            {
                user.UserStatus = UserStatus.Added;   
            }

            context.Users.AddOrUpdate(user);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
