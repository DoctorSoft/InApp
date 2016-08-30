using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsForeignerCommand : IVoidCommand
    {
        public string UserLink { get; set; }
    }
}
