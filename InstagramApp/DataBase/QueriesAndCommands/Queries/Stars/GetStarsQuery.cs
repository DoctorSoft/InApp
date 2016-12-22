using System.Collections.Generic;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Stars
{
    public class GetStarsQuery : IQuery<List<string>>
    {
        public int MaxCount { get; set; }

        public bool ToFollow { get; set; }
    }
}
