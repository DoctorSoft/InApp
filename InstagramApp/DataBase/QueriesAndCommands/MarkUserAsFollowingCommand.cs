using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class MarkUserAsFollowingCommand : IVoidCommand
    {
        public string User { get; set; }
    }
}
