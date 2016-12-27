using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;
using EntityFramework.BulkInsert.Extensions;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUsersAsToFollowCommandHandler : ICommandHandler<MarkUsersAsToFollowCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public MarkUsersAsToFollowCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(MarkUsersAsToFollowCommand command)
        {
            var exitedUsers = context.Users.Select(model => model.Link).ToList();
            var usersToAdd = command.Users.Except(exitedUsers).ToList();

            context.BulkInsert(usersToAdd.Select(s => new UserDbModel
            {
                Link = s,
                UserStatus = UserStatus.ToFollow,
            }));

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
