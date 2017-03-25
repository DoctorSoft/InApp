using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Users
{
    public class MarkUsersAsNormalCommand : IVoidCommand
    {
        public List<string> UsersToMarkAsNormal { get; set; }

    }
}
