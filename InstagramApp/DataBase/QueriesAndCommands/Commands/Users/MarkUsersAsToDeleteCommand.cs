using System.Collections.Generic;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUsersAsToDeleteCommand : IVoidCommand
    {
        public List<string> Users { get; set; } 
    }
}
