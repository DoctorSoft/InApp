using System.Data.Entity.Migrations;
using System.Linq;
using DataBase.Contexts;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class UpdateFollowingsSynchronizationTimeCommandHandler : IVoidCommandHandler<UpdateFollowingsSynchronizationTimeCommand>
    {
        private readonly DataBaseContext context;

        public UpdateFollowingsSynchronizationTimeCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(UpdateFollowingsSynchronizationTimeCommand command)
        {
            var settings = context
            .ProfileSettings
            .FirstOrDefault();

            settings.PreviousFollowingsSynchDate = command.NextTime;

            context.ProfileSettings.AddOrUpdate(settings);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
