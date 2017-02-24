using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Common;
using EntityFramework.Extensions;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class RemoveAllUsersByStatusCommandHandler : ICommandHandler<RemoveAllUsersByStatusCommand, VoidCommandResponse>
    {
        private readonly IStoreContext context;

        public RemoveAllUsersByStatusCommandHandler(IStoreContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(RemoveAllUsersByStatusCommand command)
        {
            context.Users.Where(model => model.UserStatus == command.UserStatus).Delete();

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
