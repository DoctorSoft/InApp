using System.Collections.Generic;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Users
{
    public class GetUsersToFollowCountQueryHandler : IQueryHandler<GetUsersToFollowCountQuery, int>
    {
        private readonly DataBaseContext context;

        public GetUsersToFollowCountQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public int Handle(GetUsersToFollowCountQuery query)
        {
            var count = context.Users.Count(model => model.UserStatus == UserStatus.ToFollow);

            return count;
        }
    }
}
