using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsStarCommandHandler : IVoidCommandHandler<MarkUserAsStarCommand>
    {
        private readonly DataBaseContext context;

        public MarkUserAsStarCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(MarkUserAsStarCommand command)
        {
            var user = context.Users.FirstOrDefault(model => model.Link == command.UserLink);

            if (user == null)
            {
                user = new UserDbModel
                {
                    Link = command.UserLink,
                    UserStatus = UserStatus.Star
                };
            }
            else
            {
                if (user.UserStatus == UserStatus.ImportantForOwner)
                {
                    return new VoidCommandResponse();
                }

                user.UserStatus = UserStatus.Star;
            }

            context.Users.AddOrUpdate(user);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
