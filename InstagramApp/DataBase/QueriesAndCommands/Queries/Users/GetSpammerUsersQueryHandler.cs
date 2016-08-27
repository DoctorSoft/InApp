using System.Collections.Generic;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Users
{
    public class GetSpammerUsersQueryHandler : IQueryHandler<GetSpammerUsersQuery, List<string>>
    {
        private readonly DataBaseContext context;

        public GetSpammerUsersQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<string> Handle(GetSpammerUsersQuery query)
        {
            var users = context
                .Users
                .Where(model => model.UserStatus == UserStatus.Spammer)
                .Select(model => model.Link)
                .ToList();

            return users; 
        }
    }
}
