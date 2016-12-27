using System.Collections.Generic;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Users
{
    public class GetRequiredUsersQueryHandler : IQueryHandler<GetRequiredUsersQuery, List<string>>
    {
        private readonly DataBaseContext context;

        public GetRequiredUsersQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<string> Handle(GetRequiredUsersQuery query)
        {
            var users = context
                .Users
                .Where(model => model.UserStatus == UserStatus.Required)
                .Select(model => model.Link)
                .Take(query.MaxCount)
                .ToList();

            return users;
        }
    }
}
