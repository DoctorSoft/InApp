using Constants;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Functionality
{
    public class SetFunctionalityAsAsapCommand : IVoidCommand
    {
        public FunctionalityName FunctionalityName { get; set; }
    }
}
