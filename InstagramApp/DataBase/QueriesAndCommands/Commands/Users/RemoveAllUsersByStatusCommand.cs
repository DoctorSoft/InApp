using Constants;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class RemoveAllUsersByStatusCommand : IVoidCommand
    {
        public UserStatus UserStatus { get; set; }
    }
}
