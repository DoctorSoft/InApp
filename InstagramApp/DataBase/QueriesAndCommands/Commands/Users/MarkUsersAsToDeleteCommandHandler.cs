using System.Linq;
using Constants;
using DataBase.Contexts;
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
            var allUsers = context.Users.Select(model => model.Link).ToList();
            var starsAndRequiredUsers = context.Users.Where(model => model.UserStatus == UserStatus.Star || model.UserStatus == UserStatus.Required || model.UserStatus == UserStatus.ImportantForOwner)
                .Select(model => model.Link)
                .ToList();
            var usersAlreadyMarkerAsToDelete = context.Users.Where(model => model.UserStatus == UserStatus.ToDelete).Select(model => model.Link).ToList();

            var usersToAddAsToDelete = command.Users.Except(allUsers).ToList();

            var usersToUpdateAsToDelete = command.Users.Except(usersToAddAsToDelete).Except(starsAndRequiredUsers).ToList();

            var usersToMarkAsNormal = usersAlreadyMarkerAsToDelete.Except(usersToUpdateAsToDelete).ToList();

            if (usersToMarkAsNormal.Any())
            {
                context.Users.Where(model => usersToMarkAsNormal.Contains(model.Link)).Update(model => new UserDbModel { UserStatus = UserStatus.Normal });
            }
            context.BulkInsert(usersToAddAsToDelete.Select(s => new UserDbModel
            {
                UserStatus = UserStatus.ToDelete,
                Link = s
            }));
            if (usersToUpdateAsToDelete.Any())
            {
                context.Users.Where(model => usersToUpdateAsToDelete.Contains(model.Link))
                    .Update(model => new UserDbModel {UserStatus = UserStatus.ToDelete});
            }

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
