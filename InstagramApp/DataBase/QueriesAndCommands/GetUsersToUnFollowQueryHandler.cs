using System;
using System.Collections.Generic;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class GetUsersToUnFollowQueryHandler : IQueryHandler<GetUsersToUnFollowQuery, List<string>>
    {
        private readonly DataBaseContext context;

        public GetUsersToUnFollowQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<string> Handle(GetUsersToUnFollowQuery query)
        {
            var maxDate = DateTime.Now - new TimeSpan(5, 0, 0, 0);

            var users = context
                .Users
                .Where(model => model.UserStatus == UserStatus.Following)
                .Where(model => model.IncludingTime < maxDate)
                .Select(model => model.Link)
                .Take(query.MaxCount)
                .ToList();

            return users;
        }
    }
}
