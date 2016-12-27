﻿using System.Data.Entity.Migrations;
using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
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
            settings.Proxy = command.Proxy;
            settings.ProxyLogin = command.ProxyName;
            settings.ProxyPassword = command.ProxyPassword;
            settings.RemoveAllUsers = command.RemoveAllUsers;

            context.ProfileSettings.AddOrUpdate(settings);

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
