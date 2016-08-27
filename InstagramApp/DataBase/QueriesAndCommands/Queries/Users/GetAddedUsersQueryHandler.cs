using System.Collections.Generic;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Users
{
    public class GetAddedUsersQueryHandler : IQueryHandler<GetAddedUsersQuery, List<string>>
    {
        private readonly DataBaseContext context;

        public GetAddedUsersQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<string> Handle(GetAddedUsersQuery query)
        {
            var users = context
                .Users
                .Where(model => model.UserStatus == UserStatus.Added)
                .Select(model => model.Link)
                .ToList();

            return users;
        }
    }
}
