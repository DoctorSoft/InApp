using System.Collections.Generic;
using System.Linq;
using DataBase.Contexts.LikeApplication;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.LikeApplication
{
    public class GetActiveLikeAccountIdListQueryHandler : IQueryHandler<GetActiveLikeAccountIdListQuery, List<long>>
    {
        private readonly LikeApplicationContext context;

        public GetActiveLikeAccountIdListQueryHandler(LikeApplicationContext context)
        {
            this.context = context;
        }

        public List<long> Handle(GetActiveLikeAccountIdListQuery query)
        {
            var activeAccounts = context.Accounts.Select(model => model.Id).ToList();

            return activeAccounts;
        }
    }
}
