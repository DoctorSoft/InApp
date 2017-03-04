using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsToFollowCommandHandler : IVoidCommandHandler<MarkUserAsToFollowCommand>
    {
        private readonly IStoreContext context;

        public MarkUserAsToFollowCommandHandler(IStoreContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(MarkUserAsToFollowCommand command)
        {
            var user = context.Users.FirstOrDefault(model => model.Link == command.UserLink);

            if (user == null)
            {
                user = new UserDbModel
                {
                    Link = command.UserLink,
                    UserStatus = UserStatus.ToFollow
                };
            }
            else
            {
                // if this user is in base, do nothing
                return new VoidCommandResponse();
            }

            context.Users.AddOrUpdate(user);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
