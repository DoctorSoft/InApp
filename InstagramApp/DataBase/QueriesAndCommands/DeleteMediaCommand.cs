using System.Collections.Generic;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class DeleteMediaCommand: IVoidCommand
    {
        public List<string> UrlList { get; set; }
    }
}
