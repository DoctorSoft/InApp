using System.Collections.Generic;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class AddMediaListCommand : IVoidCommand
    {
        public List<string> MediaList { get; set; } 
    }
}
