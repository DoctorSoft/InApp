using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class MarkUserAsCheckedForFriendsCommand: IVoidCommand
    {
        public string User { get; set; }
    }
}
