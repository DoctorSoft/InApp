using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.LikeApplication
{
    public class GetLikeAccountDataQuery : IQuery<LikeAccountData>
    {
        public long Id { get; set; }
    }
}
