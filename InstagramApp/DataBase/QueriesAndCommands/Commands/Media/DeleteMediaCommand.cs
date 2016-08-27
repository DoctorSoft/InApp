using System.Collections.Generic;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Media
{
    public class DeleteMediaCommand: IVoidCommand
    {
        public List<string> UrlList { get; set; }
    }
}
