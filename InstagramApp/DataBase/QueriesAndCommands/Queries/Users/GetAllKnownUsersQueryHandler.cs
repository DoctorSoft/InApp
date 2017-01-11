using System.Collections.Generic;
using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Users
{
    public class GetAllKnownUsersQueryHandler : IQueryHandler<GetAllKnownUsersQuery, List<string>>
    {
        private readonly IStoreContext context;

        public GetAllKnownUsersQueryHandler(IStoreContext context)
        {
            this.context = context;
        }

        public List<string> Handle(GetAllKnownUsersQuery query)
        {
            var users = context
                .Users.Select(model => model.Link)
                .ToList();

            return users;
        }
    }
}
