using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsToDeleteCommand : IVoidCommand
    {
        public string UserLink { get; set; }
    }
}
