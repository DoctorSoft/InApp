using System.Collections.Generic;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class GetUsersToFollowQuery : IQuery<List<string>>
    {
        public int MaxCount { get; set; }
    }
}
