using System;
using Constants;
using DataBase.Contexts.InnerTools;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Register
{
    public class AddUserToRegisterCommandHandler : ICommandHandler<AddUserToRegisterCommand, VoidCommandResponse>
    {
        private readonly IStoreContext context;

        public AddUserToRegisterCommandHandler(IStoreContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(AddUserToRegisterCommand command)
        {
            context.Users.Add(new UserDbModel
            {
                Link = command.Link,
                UserStatus = UserStatus.ImportantForOwner,
                IncludingTime = DateTime.Now,
            });

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
