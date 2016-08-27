using System.Collections.Generic;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Users
{
    public class GetForeignUsersQueryHandler : IQueryHandler<GetForeignUsersQuery, List<string>>
    {
        private readonly DataBaseContext context;

        public GetForeignUsersQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<string> Handle(GetForeignUsersQuery query)
        {
            var users = context
                .Users
                .Where(model => model.UserStatus == UserStatus.Foreigner)
                .Select(model => model.Link)
                .ToList();

            return users;
        }
    }
}
