using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;
using EntityFramework.BulkInsert.Extensions;
using EntityFramework.Extensions;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUsersAsToDeleteCommandHandler : ICommandHandler<MarkUsersAsToDeleteCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public MarkUsersAsToDeleteCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(MarkUsersAsToDeleteCommand command)
        {
            var allUsers = context.Users.Where(model => model.UserStatus == UserStatus.ImportantForOwner && model.UserStatus == UserStatus.Required).Select(model => model.Link).ToList();
            var usersToAddAsToDelete = command.UsersToClear.Except(allUsers).ToList();

            context.BulkInsert(usersToAddAsToDelete.Select(s => new UserDbModel
            {
                UserStatus = UserStatus.ToDelete,
                Link = s
            }));

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
