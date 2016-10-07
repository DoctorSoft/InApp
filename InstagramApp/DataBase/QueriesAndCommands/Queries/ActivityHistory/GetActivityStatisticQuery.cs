using System.Collections.Generic;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.ActivityHistory
{
    public class GetActivityStatisticQuery : IQuery<List<ActivityStatisticModel>>
    {
        public int MaxCount { get; set; }
    }
}
