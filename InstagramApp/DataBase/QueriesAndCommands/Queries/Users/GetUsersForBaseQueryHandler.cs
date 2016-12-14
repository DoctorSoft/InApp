using System;
using System.Collections.Generic;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Users
{
    public class GetUsersForBaseQueryHandler : IQueryHandler<GetUsersForBaseQuery, List<String>>
    {
        private readonly DataBaseContext context;

        public GetUsersForBaseQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<string> Handle(GetUsersForBaseQuery query)
        {
            var users = context
                .Users
                .Where(model => model.UserStatus == UserStatus.Required)
                .OrderBy(model => model.Id)
                .Select(model => model.Link)
                .Take(query.MaxCount)
                .ToList();

            return users;
        }
    }
}
