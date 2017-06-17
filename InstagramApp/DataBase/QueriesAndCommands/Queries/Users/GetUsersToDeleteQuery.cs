using System;
using System.Collections.Generic;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Users
{
    public class GetUsersToDeleteQuery : IQuery<List<string>>
    {
        public int MaxCount { get; set; }

        public TimeSpan BanTime { get; set; }

        public bool RemoveAllUsers { get; set; }

        public List<string> ExceptUsersList { get; set; } 
    }
}
