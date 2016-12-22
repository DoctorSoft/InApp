using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Stars
{
    public class MarkStarAsFollowedCommand : IVoidCommand
    {
        public string Link { get; set; }
    }
}
