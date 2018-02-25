using System;
using System.Collections.Generic;
using System.Linq;
using CommandPanel.Models.HomeModels;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Queries.ActivityHistory;
using DataBase.QueriesAndCommands.Queries.Functionality;
using DataBase.QueriesAndCommands.Queries.Settings;
using DataBase.QueriesAndCommands.Queries.Users;
using Tools.Factories;

namespace CommandPanel.Services
{
    public class HomeService
    {
        public List<AccountViewModel> GetAccountList()
        {
            var proxies = Enum.GetValues(typeof (AccountName))
                .Cast<AccountName>()
                .Where(name => (int)name < 1000)
                .Select(name => new AccountViewModel
                {
                    Name = name.ToString("G"),
                    AccountId = name,
                })
                .ToList();

            foreach (var proxy in proxies)
            {
                var context = new ContextFactory().GetContext(proxy.AccountId);
                var profileSettings = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery { });

                proxy.ProxyLogin = profileSettings.ProxyLogin;
                proxy.ProxyPassword = profileSettings.ProxyPassword;
                
                var statisticData = new GetLastActivityHistoryRecordQueryHandler(context).Handle(new GetLastActivityHistoryRecordQuery());
                var userProcessingStatistic = new GetUserProcessingStatisticQueryHandler(context).Handle(new GetUserProcessingStatisticQuery());

                var chart = new GetActivityStatisticQueryHandler(context).Handle(new GetActivityStatisticQuery { MaxCount = 2 });

                proxy.Followers = statisticData.FollowersCount;
                proxy.Following = statisticData.FollowingsCount;
                proxy.UsersToFollow = userProcessingStatistic.UsersToFollowCount;
                if (chart.Any())
                {
                    proxy.Difference = chart.FirstOrDefault().Followers - chart.LastOrDefault().Followers;
                }
                else
                {
                    proxy.Difference = 0;
                }
                proxy.Url = profileSettings.HomePageUrl;
            }

            return proxies;
        } 
    }
}