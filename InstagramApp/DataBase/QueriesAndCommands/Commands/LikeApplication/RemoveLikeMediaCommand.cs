using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.LikeApplication
{
    public class RemoveLikeMediaCommand : IVoidCommand
    {
        public string Link { get; set; }
    }
}
