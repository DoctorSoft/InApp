using System.Data.Entity.Migrations;
using System.Linq;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Settings
{
    public class UpdateLoginSettingsCommandHandler : ICommandHandler<UpdateLoginSettingsCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public UpdateLoginSettingsCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(UpdateLoginSettingsCommand command)
        {
            var settings = context.ProfileSettings.FirstOrDefault();

            settings.Password = command.Password;
            settings.HomePageUrl = command.HomePage;
            settings.Login = command.Login;

            context.ProfileSettings.AddOrUpdate(settings);

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
