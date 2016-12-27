using System.Collections.Generic;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Users
{
    public class GetUsersNotCheckedForFriendsQueryHandler : IQueryHandler<GetUsersNotCheckedForFriendsQuery, List<string>>
    {
        private readonly DataBaseContext context;

        public GetUsersNotCheckedForFriendsQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<string> Handle(GetUsersNotCheckedForFriendsQuery query)
        {
            var userList = context.Users
                .Where(model => !model.FriendsWereSearched && model.UserStatus == UserStatus.Required)
                .Select(model => model.Link)
                .Take(query.MaxCount)
                .ToList();
            return userList;
        }
    }
}
