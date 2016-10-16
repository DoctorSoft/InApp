using DataBase.Contexts.LikeApplication;
using DataBase.Models.LikeApplication;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Proxy
{
    public class SaveLikeAccountCommandHandler : ICommandHandler<SaveLikeAccountCommand, VoidCommandResponse>
    {
        private readonly LikeApplicationContext context;

        public SaveLikeAccountCommandHandler(LikeApplicationContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(SaveLikeAccountCommand command)
        {
            context.Accounts.Add(new LikeAccountDbModel
            {
                Name = command.Name,
                Password = command.Password,
                Email = command.Email,
                Link = command.Link
            });

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
