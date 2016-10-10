using System.Linq;
using DataBase.Contexts.LikeApplication;
using DataBase.Models.LikeApplication;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Proxy
{
    public class SaveProxyListCommandHandler : ICommandHandler<SaveProxyListCommand, VoidCommandResponse>
    {
        private readonly LikeApplicationContext context;

        public SaveProxyListCommandHandler(LikeApplicationContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(SaveProxyListCommand command)
        {
            var proxies = command.Proxies.Select(s => new ProxyDbModel
            {
                IpAddress = s.Split(':').FirstOrDefault(),
                Port = s.Split(':').LastOrDefault()
            });

            context.Proxies.AddRange(proxies);

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
