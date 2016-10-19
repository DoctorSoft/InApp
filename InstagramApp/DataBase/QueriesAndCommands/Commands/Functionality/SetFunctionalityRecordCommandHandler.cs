using System;
using DataBase.Contexts;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Functionality
{
    public class SetFunctionalityRecordCommandHandler : ICommandHandler<SetFunctionalityRecordCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public SetFunctionalityRecordCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(SetFunctionalityRecordCommand command)
        {
            var record = new FunctionalityRecordDbModel
            {
                Name = command.Name,
                DateTime = DateTime.Now,
                Note = command.Note,
                WorkStatus = command.WorkStatus
            };

            context.FunctionalityRecords.Add(record);

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
