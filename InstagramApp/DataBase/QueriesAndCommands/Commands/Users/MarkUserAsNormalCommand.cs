using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsNormalCommand : IVoidCommand
    {
        public string UserLink { get; set; }
    }
}
