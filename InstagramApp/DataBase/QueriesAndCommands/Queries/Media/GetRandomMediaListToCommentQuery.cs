using System.Collections.Generic;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Media
{
    public class GetRandomMediaListToCommentQuery: IQuery<List<string>>
    {
        public int CountMedia { get; set; }
    }
}
