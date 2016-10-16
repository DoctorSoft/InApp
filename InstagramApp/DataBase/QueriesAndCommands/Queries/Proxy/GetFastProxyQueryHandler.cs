using System;
using System.Linq;
using DataBase.Contexts.LikeApplication;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Proxy
{
    public class GetFastProxyQueryHandler : IQueryHandler<GetFastProxyQuery, ProxyModel>
    {        
        private readonly LikeApplicationContext context;

        public GetFastProxyQueryHandler(LikeApplicationContext context)
        {
            this.context = context;
        }

        public ProxyModel Handle(GetFastProxyQuery query)
        {
            var result = context.Proxies
                .OrderBy(model => model.Speed)
                .Select(model => new ProxyModel
                {
                    Port = model.Port,
                    IpAddress = model.IpAddress,
                    Speed = model.Speed
                })
                .FirstOrDefault();

            return result;
        }
    }
}
