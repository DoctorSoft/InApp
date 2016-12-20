using System.Collections.Generic;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Stars
{
    public class AddStarsCommand : IVoidCommand
    {
        public List<string> StarsUrls { get; set; } 
    }
}
