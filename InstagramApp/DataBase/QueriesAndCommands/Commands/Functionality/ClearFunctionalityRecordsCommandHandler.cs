using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;
using EntityFramework.Extensions;

namespace DataBase.QueriesAndCommands.Commands.Functionality
{
    public class ClearFunctionalityRecordsCommandHandler : ICommandHandler<ClearFunctionalityRecordsCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public ClearFunctionalityRecordsCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(ClearFunctionalityRecordsCommand command)
        {
            context.FunctionalityRecords.Delete();
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
