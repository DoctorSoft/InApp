using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class RemoveUserCommand : IVoidCommand
    {
        public string UserLink { get; set; }
    }
}
