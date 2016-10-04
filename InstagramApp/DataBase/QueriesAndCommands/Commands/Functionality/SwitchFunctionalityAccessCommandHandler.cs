using System.Data.Entity.Migrations;
using System.Linq;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Functionality
{
    public class SwitchFunctionalityAccessCommandHandler : ICommandHandler<SwitchFunctionalityAccessCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public SwitchFunctionalityAccessCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(SwitchFunctionalityAccessCommand command)
        {
            var functionality =
                context.Functionalities.FirstOrDefault(model => model.FunctionalityNumber == command.FunctionalityName);

            functionality.Stopped = !functionality.Stopped;

            context.Functionalities.AddOrUpdate(functionality);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
