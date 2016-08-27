using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsSpammerCommand : IVoidCommand
    {
        public string UserLink { get; set; }
    }
}
