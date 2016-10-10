using System.Linq;
using DataBase.Contexts.LikeApplication;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.LikeApplication
{
    public class RemoveAccountToLikeMediaCommandHandler : ICommandHandler<RemoveAccountToLikeMediaCommand, VoidCommandResponse>
    {
        private readonly LikeApplicationContext context;

        public RemoveAccountToLikeMediaCommandHandler(LikeApplicationContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(RemoveAccountToLikeMediaCommand command)
        {
            var accountRecordToDelete =
                context.AccountsToLikeMedias.FirstOrDefault(
                    model =>
                        model.LikeAccountId == command.LikeAccountId &&
                        model.LikeMedia.Link.ToUpper() == command.LikeMediaLink.ToUpper());

            context.AccountsToLikeMedias.Remove(accountRecordToDelete);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
