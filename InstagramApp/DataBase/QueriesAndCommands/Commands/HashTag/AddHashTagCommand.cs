using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.HashTag
{
    public class AddHashTagCommand : IVoidCommand
    {
        public string HashTag { get; set; }
    }
}
