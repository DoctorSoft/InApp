using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class MarkUserAsFollowingCommand : IVoidCommand
    {
        public string UserLink { get; set; }
    }
}
