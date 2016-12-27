using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Users
{
    public class GetUsersToDeleteCountQueryHandler : IQueryHandler<GetUsersToDeleteCountQuery, int>
    {
        private readonly DataBaseContext context;

        public GetUsersToDeleteCountQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public int Handle(GetUsersToDeleteCountQuery query)
        {
            var count = context.Users.Count(model => model.UserStatus == UserStatus.ToDelete);

            return count;
        }
    }
}
