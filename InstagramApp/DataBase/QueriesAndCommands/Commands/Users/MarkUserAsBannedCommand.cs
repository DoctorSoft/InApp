using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsBannedCommand : IVoidCommand
    {
        public string User { get; set; }
    }
}
