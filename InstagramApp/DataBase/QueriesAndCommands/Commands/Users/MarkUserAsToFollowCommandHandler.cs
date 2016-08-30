using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsToFollowCommandHandler : IVoidCommandHandler<MarkUserAsToFollowCommand>
    {
        private readonly DataBaseContext context;

        public MarkUserAsToFollowCommandHandler(DataBaseContext context)
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
                user.UserStatus = UserStatus.ToFollow;
            }

            context.Users.AddOrUpdate(user);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
