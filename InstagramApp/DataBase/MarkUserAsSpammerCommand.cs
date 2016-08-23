using DataBase.QueriesAndCommands.Common;

namespace DataBase
{
    public class MarkUserAsSpammerCommand : IVoidCommand
    {
        public string UserLink { get; set; }
    }
}
