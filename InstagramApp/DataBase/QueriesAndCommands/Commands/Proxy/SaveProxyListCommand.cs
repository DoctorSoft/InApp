using System.Collections.Generic;
using DataBase.QueriesAndCommands.Common;
using DataBase.QueriesAndCommands.Queries.Proxy;

namespace DataBase.QueriesAndCommands.Commands.Proxy
{
    public class SaveProxyListCommand : IVoidCommand
    {
        public List<ProxyModel> Proxies { get; set; } 
    }
}
