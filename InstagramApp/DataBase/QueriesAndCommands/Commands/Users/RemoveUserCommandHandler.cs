using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class RemoveUserCommandHandler : ICommandHandler<RemoveUserCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public RemoveUserCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(RemoveUserCommand command)
        {
            var userToDelete = context.Users.FirstOrDefault(model => model.Link.ToUpper() == command.UserLink.ToUpper());

            if (userToDelete == null)
            {
                return new VoidCommandResponse();
            }

            context.Users.Remove(userToDelete);

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
