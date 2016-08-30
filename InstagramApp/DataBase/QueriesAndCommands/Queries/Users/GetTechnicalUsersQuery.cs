using System.Collections.Generic;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Users
{
    public class GetTechnicalUsersQuery : IQuery<List<string>>
    {
        public int MaxCount { get; set; }
    }
}
