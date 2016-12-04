using System.Collections.Generic;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Media
{
    public class GetMediaToLikeQuery : IQuery<List<string>>
    {
        public int MaxCount { get; set; }
    }
}
