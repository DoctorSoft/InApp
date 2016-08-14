using System.Collections.Generic;
using System.IO;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class GetTechnicalUsersQuery : IQuery<List<string>>
    {
        public int MaxCount { get; set; }
    }
}
