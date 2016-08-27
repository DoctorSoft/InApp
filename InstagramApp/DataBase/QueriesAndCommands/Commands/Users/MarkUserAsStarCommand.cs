using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUserAsStarCommand : IVoidCommand
    {
        public string UserLink { get; set; }
    }
}
