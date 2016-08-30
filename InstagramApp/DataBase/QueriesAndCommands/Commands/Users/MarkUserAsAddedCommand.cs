using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsAddedCommand : IVoidCommand
    {
        public string UserLink { get; set; }
    }
}
