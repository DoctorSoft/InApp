using System.Collections.Generic;
using System.Linq;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
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
                .Where(model => !model.FriendsWereSearched)
                .Select(model => model.Link)
                .Take(query.MaxCount)
                .ToList();
            return userList;
        }
    }
}
