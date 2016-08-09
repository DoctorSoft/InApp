using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class MarkUserAsBannedCommand : IVoidCommand
    {
        public string User { get; set; }
    }
}
