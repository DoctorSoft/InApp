using Constants;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Functionality
{
    public class RemoveFunctionalityTokenCommand : IVoidCommand
    {
        public FunctionalityName FunctionalityName { get; set; }
    }
}
