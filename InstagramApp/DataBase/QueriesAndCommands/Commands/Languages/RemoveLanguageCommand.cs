using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Languages
{
    public class RemoveLanguageCommand : IVoidCommand
    {
        public string Language { get; set; }
    }
}
