using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class MarkUserAsStarCommand : IVoidCommand
    {
        public string UserLink { get; set; }
    }
}
