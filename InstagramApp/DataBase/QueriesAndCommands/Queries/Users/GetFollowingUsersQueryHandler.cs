using System.Collections.Generic;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Users
{
    public class GetFollowingUsersQueryHandler : IQueryHandler<GetFollowingUsersQuery, List<string>>
    {
        private readonly DataBaseContext context;

        public GetFollowingUsersQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<string> Handle(GetFollowingUsersQuery query)
        {
            var users = context
                .Users
                .Where(model => model.UserStatus == UserStatus.Following)
                .Select(model => model.Link)
                .Take(query.MaxCount)
                .ToList();

            return users;
        }
    }
}
