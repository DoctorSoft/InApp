using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Users
{
    public class GetUserProcessingStatisticQuery : IQuery<UserProcessingStatistic>
    {
        public bool RemoveAllUsers { get; set; }
    }
}
