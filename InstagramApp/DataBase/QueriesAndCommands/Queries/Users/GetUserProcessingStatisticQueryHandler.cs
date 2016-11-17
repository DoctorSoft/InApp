using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Users
{
    public class GetUserProcessingStatisticQueryHandler : IQueryHandler<GetUserProcessingStatisticQuery, UserProcessingStatistic>
    {
        private readonly DataBaseContext context;

        public GetUserProcessingStatisticQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public UserProcessingStatistic Handle(GetUserProcessingStatisticQuery query)
        {
            var usersToFollowCount = context.Users.Count(model => model.UserStatus == UserStatus.ToFollow);
            var usersToDeleteCount = context.Users.Count(model => model.UserStatus == UserStatus.ToDelete || (query.RemoveAllUsers && model.UserStatus == UserStatus.Normal));

            return new UserProcessingStatistic
            {
                UsersToDeleteCount = usersToDeleteCount,
                UsersToFollowCount = usersToFollowCount
            };
        }
    }
}
