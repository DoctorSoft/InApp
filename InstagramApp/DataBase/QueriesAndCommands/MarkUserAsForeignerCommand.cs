using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class MarkUserAsForeignerCommand : IVoidCommand
    {
        public string UserLink { get; set; }
    }
}
