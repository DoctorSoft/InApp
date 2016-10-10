using System.Collections.Generic;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Proxy
{
    public class SaveProxyListCommand : IVoidCommand
    {
        public List<string> Proxies { get; set; } 
    }
}
