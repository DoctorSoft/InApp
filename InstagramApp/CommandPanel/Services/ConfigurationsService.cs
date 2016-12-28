using CommandPanel.Models.ConfigurationsModels;
using Constants;
using DataBase.QueriesAndCommands.Commands.Settings;
using DataBase.QueriesAndCommands.Queries.Settings;
using Tools.Factories;

namespace CommandPanel.Services
{
    public class ConfigurationsService
    {
        public ConfigurationsViewModel GetConfigurations(AccountName accountId)
        {
            var context = new ContextFactory().GetContext(accountId);
            
            var configs = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());

            return new ConfigurationsViewModel
            {
                AccountId = accountId,
                Password = configs.Password,
                Login = configs.Login,
                HomePage = configs.HomePageUrl,
                Proxy = configs.Proxy,
                ProxyName = configs.ProxyLogin,
                ProxyPassword = configs.ProxyPassword,
                RemoveAllUsers = configs.RemoveAllUsers,
                InstagramId = configs.InstagramtId.ToString()
            };
        }

        public void UpdateConfigurations(AccountName accountId, ConfigurationsDraftModel model)
        {
            var context = new ContextFactory().GetContext(accountId);

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
                InstagramId = long.Parse(model.InstagramId)
            });
        }
    }
}