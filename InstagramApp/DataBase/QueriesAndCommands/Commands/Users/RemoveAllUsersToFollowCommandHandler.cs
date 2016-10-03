using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;
using EntityFramework.Extensions;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class RemoveAllUsersToFollowCommandHandler : ICommandHandler<RemoveAllUsersToFollowCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public RemoveAllUsersToFollowCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(RemoveAllUsersToFollowCommand command)
        {
            context.Users.Where(model => model.UserStatus == UserStatus.ToFollow).Delete();

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
