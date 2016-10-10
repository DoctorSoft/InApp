using System;
using System.Linq;
using DataBase.Contexts.LikeApplication;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Proxy
{
    public class GetRandomProxyQueryHandler : IQueryHandler<GetRandomProxyQuery, ProxyModel>
    {
        private readonly LikeApplicationContext context;

        public GetRandomProxyQueryHandler(LikeApplicationContext context)
        {
            this.context = context;
        }

        public ProxyModel Handle(GetRandomProxyQuery query)
        {
            var result = context.Proxies
                .OrderBy(model => Guid.NewGuid())
                .Select(model => new ProxyModel
                {
                    Port = model.Port,
                    IpAddress = model.IpAddress
                })
                .FirstOrDefault();

            return result;
        }
    }
}
