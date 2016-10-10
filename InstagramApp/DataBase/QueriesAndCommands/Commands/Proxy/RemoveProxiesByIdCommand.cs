using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Proxy
{
    public class RemoveProxiesByIdCommand : IVoidCommand
    {
        public string IpAddress { get; set; }
    }
}
