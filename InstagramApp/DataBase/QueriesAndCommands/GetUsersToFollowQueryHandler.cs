using System.Collections.Generic;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class GetUsersToFollowQueryHandler : IQueryHandler<GetUsersToFollowQuery, List<string>>
    {
        private readonly DataBaseContext context;

        public GetUsersToFollowQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<string> Handle(GetUsersToFollowQuery query)
        {
            var users = context
                .Users
                .Where(model => model.UserStatus == UserStatus.ToFollow)
                .Select(model => model.Link)
                .Take(query.MaxCount)
                .ToList();

            return users;
        }
    }
}
