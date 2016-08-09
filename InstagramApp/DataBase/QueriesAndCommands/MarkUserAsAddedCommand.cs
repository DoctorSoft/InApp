using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class MarkUserAsAddedCommand : IVoidCommand
    {
        public string User { get; set; }
    }
}
