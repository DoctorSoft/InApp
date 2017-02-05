using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Register
{
    public class AddUserToRegisterCommand : IVoidCommand
    {
        public string Link { get; set; }
    }
}
