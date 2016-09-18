using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.History
{
    public class AddFollowersNoteCommand : IVoidCommand
    {
        public int FollowersCount { get; set; }
    }
}
