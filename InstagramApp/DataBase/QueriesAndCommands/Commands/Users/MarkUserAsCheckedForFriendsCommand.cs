using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsCheckedForFriendsCommand: IVoidCommand
    {
        public string User { get; set; }
    }
}
