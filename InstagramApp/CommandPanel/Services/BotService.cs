using System;
using System.Collections.Generic;
using System.Linq;
using CommandPanel.Models.ConfigurationsModels;
using CommandPanel.Models.HomeModels;
using Constants;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Commands.Settings;
using DataBase.QueriesAndCommands.Queries.Settings;
using Tools.Factories;

namespace CommandPanel.Services
{
    public class BotService
    {
        public List<ConfigurationsViewModel> GetConfigurations()
        {
            var bots = Enum.GetValues(typeof(AccountName))
                .Cast<AccountName>()
                .Where(name => (int)name > 1000)
                .Select(name => new AccountViewModel
                {
                    Name = name.ToString("G"),
                    AccountId = name

                })
                .ToList();

            var result = new List<ConfigurationsViewModel>();

            foreach (var bot in bots)
            {
                var context = new ContextFactory().GetBotContext(bot.AccountId); 
                var handler = new GetProfileSettingsQueryHandler(context);
                var configs = handler.Handle(new GetProfileSettingsQuery());

                var botModel = new ConfigurationsViewModel
                {
                    AccountId = bot.AccountId,
                    Password = configs.Password,
                    Login = configs.Login,
                    HomePage = configs.HomePageUrl,
                    Proxy = configs.Proxy,
                    ProxyName = configs.ProxyLogin,
                    ProxyPassword = configs.ProxyPassword,
                    RemoveAllUsers = configs.RemoveAllUsers,
                    InstagramId = configs.InstagramtId.ToString()
                };

                result.Add(botModel);
            }

            return result;
        }

        public void UpdateConfigurations(AccountName accountId, ConfigurationsDraftModel model)
        {
            var context = new ContextFactory().GetBotContext(accountId);

            new UpdateLoginSettingsCommandHandler(context).Handle(new UpdateLoginSettingsCommand
            {
                Password = model.Password,
                Login = model.Login,
                HomePage = model.HomePage,
                AccountId = accountId,
                Proxy = model.Proxy,
                ProxyPassword = model.ProxyPassword,
                ProxyName = model.ProxyName,
                RemoveAllUsers = model.RemoveAllUsers,
                InstagramId = long.Parse(model.InstagramId ?? "0")
            });
        }
    }
}