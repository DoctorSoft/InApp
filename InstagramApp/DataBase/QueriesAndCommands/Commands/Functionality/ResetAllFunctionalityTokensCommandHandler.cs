using DataBase.Contexts;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;
using EntityFramework.Extensions;

namespace DataBase.QueriesAndCommands.Commands.Functionality
{
    public class ResetAllFunctionalityTokensCommandHandler : ICommandHandler<ResetAllFunctionalityTokensCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public ResetAllFunctionalityTokensCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(ResetAllFunctionalityTokensCommand command)
        {
            context.Functionalities.Update(model => new FunctionalityDbModel {Token = null});
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
