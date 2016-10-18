using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Users
{
    public class GetUsersImpotantForOwnerQueryHandler : IQueryHandler<GetUsersImpotantForOwnerQuery, List<String>>
    {
        private readonly DataBaseContext context;

        public GetUsersImpotantForOwnerQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<string> Handle(GetUsersImpotantForOwnerQuery query)
        {
            var users = context
                .Users
                .Where(model => model.UserStatus == UserStatus.ImportantForOwner)
                .Select(model => model.Link)
                .OrderBy(s => Guid.NewGuid())
                .Take(query.MaxCount)
                .ToList();

            return users;
        }
    }
}
