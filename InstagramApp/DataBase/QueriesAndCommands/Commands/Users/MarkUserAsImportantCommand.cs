using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsImportantCommand : IVoidCommand
    {
        public string UserLink { get; set; }
    }
}
