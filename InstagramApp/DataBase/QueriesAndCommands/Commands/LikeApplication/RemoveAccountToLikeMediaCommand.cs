using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.LikeApplication
{
    public class RemoveAccountToLikeMediaCommand : IVoidCommand
    {
        public long LikeAccountId { get; set; }

        public string LikeMediaLink { get; set; }
    }
}
