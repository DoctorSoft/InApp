using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsRequiredCommand : IVoidCommand
    {
        public string UserLink { get; set; }
    }
}
