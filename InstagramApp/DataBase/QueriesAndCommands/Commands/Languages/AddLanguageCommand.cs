using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Languages
{
    public class AddLanguageCommand : IVoidCommand
    {
        public string Language { get; set; }
    }
}
