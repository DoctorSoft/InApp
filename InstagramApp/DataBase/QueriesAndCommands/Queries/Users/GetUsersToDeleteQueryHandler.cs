using System;
using System.Collections.Generic;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Users
{
    public class GetUsersToDeleteQueryHandler : IQueryHandler<GetUsersToDeleteQuery, List<string>>
    {
        private readonly DataBaseContext context;

        public GetUsersToDeleteQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<string> Handle(GetUsersToDeleteQuery query)
        {
            var users = context
                .Users
                .Where(model => model.UserStatus == UserStatus.ToDelete || (query.RemoveAllUsers && model.UserStatus == UserStatus.Normal))
                .Select(model => model.Link)
                .OrderBy(s => Guid.NewGuid())
                .Take(query.MaxCount)
                .ToList();

            return users;
        }
    }
}
