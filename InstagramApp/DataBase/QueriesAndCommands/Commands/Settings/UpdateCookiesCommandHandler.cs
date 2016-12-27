using System.Data.Entity.Migrations;
using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Settings
{
    public class UpdateCookiesCommandHandler : ICommandHandler<UpdateCookiesCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public UpdateCookiesCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(UpdateCookiesCommand command)
        {
            var settings = context.ProfileSettings.FirstOrDefault();

            settings.Cookies = command.Cookies;

            context.ProfileSettings.AddOrUpdate(settings);

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
