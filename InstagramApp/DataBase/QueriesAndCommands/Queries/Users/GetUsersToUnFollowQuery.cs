using System;
using System.Collections.Generic;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Users
{
    public class GetUsersToUnFollowQuery : IQuery<List<string>>
    {
        public int MaxCount { get; set; }

        public TimeSpan BanTime { get; set; }
    }
}
