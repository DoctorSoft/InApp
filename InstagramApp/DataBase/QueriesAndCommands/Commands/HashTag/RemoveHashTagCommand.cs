using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.HashTag
{
    public class RemoveHashTagCommand : IVoidCommand
    {
        public string HashTag { get; set; }
    }
}
