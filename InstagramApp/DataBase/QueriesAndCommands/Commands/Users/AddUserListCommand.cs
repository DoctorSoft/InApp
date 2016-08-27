using System.Collections.Generic;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class AddUserListCommand : IVoidCommand
    {
        public List<string> Users { get; set; } 
    }
}
