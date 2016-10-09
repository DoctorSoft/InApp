using System.Linq;
using DataBase.Contexts.LikeApplication;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.LikeApplication
{
    public class GetLikeAccountDataQueryHandler : IQueryHandler<GetLikeAccountDataQuery, LikeAccountData>
    {
        private readonly LikeApplicationContext context;

        public GetLikeAccountDataQueryHandler(LikeApplicationContext context)
        {
            this.context = context;
        }

        public LikeAccountData Handle(GetLikeAccountDataQuery query)
        {
            var account = context
                .Accounts
                .Where(model => model.Id == query.Id)
                .Select(model => new LikeAccountData
                {
                    Password = model.Password,
                    Login = model.Name,
                })
                .FirstOrDefault();

            var medias = context
                .AccountsToLikeMedias
                .Where(model => model.LikeAccountId == query.Id)
                .Select(model => model.LikeMedia.Link)
                .ToList();

            account.MediasToLike = medias;

            return account;
        }
    }
}
