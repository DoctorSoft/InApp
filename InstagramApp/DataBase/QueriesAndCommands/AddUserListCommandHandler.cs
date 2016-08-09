using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class AddUserListCommandHandler : IVoidCommandHandler<AddUserListCommand>
    {
        private readonly DataBaseContext context;

        public AddUserListCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(AddUserListCommand command)
        {
            var users = command.Users
                .Except(context.Users.Select(model => model.Link))
                .Select(s => new UserDbModel
                {
                    ConfirmedByAdmin = false,
                    UserStatus = UserStatus.ToFollow,
                    Link = s
                });

            context.Users.AddRange(users);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
