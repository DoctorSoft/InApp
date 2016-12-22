using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Stars
{
    public class MarkStarAsUnfollowedCommand : IVoidCommand
    {
        public string Link { get; set; }
    }
}
