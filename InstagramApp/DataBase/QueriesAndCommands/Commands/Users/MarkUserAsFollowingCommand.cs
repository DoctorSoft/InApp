using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsFollowingCommand : IVoidCommand
    {
        public string UserLink { get; set; }
    }
}
