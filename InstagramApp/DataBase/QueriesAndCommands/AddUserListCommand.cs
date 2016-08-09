using System.Collections.Generic;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class AddUserListCommand : IVoidCommand
    {
        public List<string> Users { get; set; } 
    }
}
