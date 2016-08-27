using System.Collections.Generic;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Users
{
    public class GetTechnicalUsersQueryHandler : IQueryHandler<GetTechnicalUsersQuery, List<string>>
    {
        private readonly DataBaseContext context;

        public GetTechnicalUsersQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<string> Handle(GetTechnicalUsersQuery query)
        {
            var users = context
                .Users
                .Where(model => model.UserStatus == UserStatus.Technical)
                .Select(model => model.Link)
                .Take(query.MaxCount)
                .ToList();

            return users;
        }
    }
}
