using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class MarkUserAsFollowingCommandHandler : IVoidCommandHandler<MarkUserAsFollowingCommand>
    {
        private readonly DataBaseContext context;

        public MarkUserAsFollowingCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(MarkUserAsFollowingCommand command)
        {
            var user = context.Users.FirstOrDefault(model => model.Link == command.User);

            user.UserStatus = UserStatus.Following;
            user.IncludingTime = DateTime.Now;

            context.Users.AddOrUpdate(user);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
