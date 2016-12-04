using System.Linq;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Languages
{
    public class RemoveLanguageCommandHandler : ICommandHandler<RemoveLanguageCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public RemoveLanguageCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(RemoveLanguageCommand command)
        {
            var language = context.Languages.FirstOrDefault(model => model.Name.ToUpper() == command.Language.ToUpper());

            context.Languages.Remove(language);

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
