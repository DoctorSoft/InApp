using Constants;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Functionality
{
    public class SetFunctionalityRecordCommand : IVoidCommand
    {
        public FunctionalityName Name { get; set; }

        public WorkStatus WorkStatus { get; set; }

        public string Note { get; set; }
    }
}
