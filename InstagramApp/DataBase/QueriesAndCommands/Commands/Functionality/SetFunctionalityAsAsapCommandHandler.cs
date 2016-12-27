using System.Data.Entity.Migrations;
using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Functionality
{
    public class SetFunctionalityAsAsapCommandHandler : ICommandHandler<SetFunctionalityAsAsapCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public SetFunctionalityAsAsapCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(SetFunctionalityAsAsapCommand command)
        {
            var functionality =
                context.Functionalities.FirstOrDefault(model => model.FunctionalityNumber == command.FunctionalityName);

            functionality.Asap = true;

            context.Functionalities.AddOrUpdate(functionality);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
