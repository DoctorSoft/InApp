﻿using System;
using System.Data.Entity.Migrations;
using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;
using LikeBotMigrator;

namespace DataBase.QueriesAndCommands.Commands.Settings
{
    public class UpdateLoginSettingsCommandHandler : ICommandHandler<UpdateLoginSettingsCommand, VoidCommandResponse>
    {
        private readonly ISettingsContext context;

        public UpdateLoginSettingsCommandHandler(ISettingsContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(UpdateLoginSettingsCommand command)
        {
            var settings = context.ProfileSettings.FirstOrDefault();

            if (settings == null)
            {
                settings = new ProfileSettingsDbModel();
            }

            settings.Password = command.Password;
            settings.HomePageUrl = command.HomePage;
            settings.Login = command.Login;
            settings.Proxy = command.Proxy;
            settings.ProxyLogin = command.ProxyName;
            settings.ProxyPassword = command.ProxyPassword;
            settings.RemoveAllUsers = command.RemoveAllUsers;
            settings.InstagramtId = command.InstagramId;

            context.ProfileSettings.AddOrUpdate(settings);

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
