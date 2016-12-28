using System;
using System.Collections.Generic;
using System.Linq;
using CommandPanel.Models.ConfigurationsModels;
using CommandPanel.Models.HomeModels;
using Constants;
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
                using (var context = new ContextFactory().GetBotContext(bot.AccountId))
                {
                    var configs = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());

                    var botModel = new ConfigurationsViewModel
                    {
                        AccountId = bot.AccountId,
                        Password = configs.Password,
                        Login = configs.Login,
                        HomePage = configs.HomePageUrl,
                        Proxy = configs.Proxy,
                        ProxyName = configs.ProxyLogin,
                        ProxyPassword = configs.ProxyPassword,
                        RemoveAllUsers = configs.RemoveAllUsers
                    };

                    result.Add(botModel);
                }
            }

            return result;
        }
    }
}