using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsToFollowCommand : IVoidCommand
    {
        public string UserLink { get; set; }
    }
}
