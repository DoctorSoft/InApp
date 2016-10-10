using System.Linq;
using DataBase.Contexts.LikeApplication;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Proxy
{
    public class RemoveProxiesByIdCommandHandler : ICommandHandler<RemoveProxiesByIdCommand, VoidCommandResponse>
    {
        private readonly LikeApplicationContext context;

        public RemoveProxiesByIdCommandHandler(LikeApplicationContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(RemoveProxiesByIdCommand command)
        {
            var proxiesToRemove =
                context.Proxies.Where(model => model.IpAddress.ToUpper() == command.IpAddress.ToUpper());

            context.Proxies.RemoveRange(proxiesToRemove);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
