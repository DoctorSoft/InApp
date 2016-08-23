using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class MarkUserAsSpammerCommand : IVoidCommand
    {
        public string UserLink { get; set; }
    }
}
