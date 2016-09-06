using System.Data.Entity.Migrations;
using System.Linq;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Functionality
{
    public class RemoveFunctionalityTokenCommandHandler : IVoidCommandHandler<RemoveFunctionalityTokenCommand>
    {
        private readonly DataBaseContext context;

        public RemoveFunctionalityTokenCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(RemoveFunctionalityTokenCommand command)
        {
            var functionality =
                context.Functionalities.FirstOrDefault(model => model.FunctionalityNumber == command.FunctionalityName);

            functionality.Token = null;
            context.Functionalities.AddOrUpdate(functionality);

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
