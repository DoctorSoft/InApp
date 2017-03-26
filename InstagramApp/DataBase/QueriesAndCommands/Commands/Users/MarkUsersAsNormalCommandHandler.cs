using System.Linq;
using Constants;
using DataBase.Contexts.InnerTools;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUsersAsNormalCommandHandler : ICommandHandler<MarkUsersAsNormalCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public MarkUsersAsNormalCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(MarkUsersAsNormalCommand command)
        {
            var allUsers = context.Users.Where(model => model.UserStatus == UserStatus.ImportantForOwner && model.UserStatus == UserStatus.Required).Select(model => model.Link).ToList();
            var usersToAddAsToDelete = command.UsersToMarkAsNormal.Except(allUsers).ToList();

            context.BulkInsert(usersToAddAsToDelete.Select(s => new UserDbModel
            {
                UserStatus = UserStatus.Normal,
                Link = s
            }));

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
