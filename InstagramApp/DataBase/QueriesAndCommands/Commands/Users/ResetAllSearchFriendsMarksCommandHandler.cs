using DataBase.Contexts;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;
using EntityFramework.Extensions;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class ResetAllSearchFriendsMarksCommandHandler : ICommandHandler<ResetAllSearchFriendsMarksCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public ResetAllSearchFriendsMarksCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(ResetAllSearchFriendsMarksCommand command)
        {
            context.Users
                    .Update(model => new UserDbModel { FriendsWereSearched = false });
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
