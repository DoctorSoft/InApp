using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsBannedCommandHandler : IVoidCommandHandler<MarkUserAsBannedCommand>
    {
        private readonly DataBaseContext context;

        public MarkUserAsBannedCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(MarkUserAsBannedCommand command)
        {
            var user = context.Users.FirstOrDefault(model => model.Link == command.User);

            user.UserStatus = UserStatus.Banned;

            context.Users.AddOrUpdate(user);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
