using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Languages
{
    public class AddLanguageCommandHandler : ICommandHandler<AddLanguageCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public AddLanguageCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(AddLanguageCommand command)
        {
            var therIsLanguage = context.Languages.Any(model => model.Name.ToUpper() == command.Language.ToUpper());

            if (!therIsLanguage)
            {
                var language = new LanguageDbModel
                {
                    Name = command.Language
                };

                context.Languages.Add(language);

                context.SaveChanges();
            }

            return new VoidCommandResponse();
        }
    }
}
