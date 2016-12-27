using System.Data.Entity.Migrations;
using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsCheckedForFriendsCommandHandler : ICommandHandler<MarkUserAsCheckedForFriendsCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public MarkUserAsCheckedForFriendsCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(MarkUserAsCheckedForFriendsCommand command)
        {
            var user = context.Users.FirstOrDefault(model => model.Link == command.User);

            user.FriendsWereSearched = true;

            context.Users.AddOrUpdate(user);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
