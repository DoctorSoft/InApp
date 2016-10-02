using System.Linq;
using CommandPanel.Models.AccountModels;
using Constants;
using DataBase.Factories;
using DataBase.QueriesAndCommands.Queries.ActivityHistory;
using DataBase.QueriesAndCommands.Queries.Features;
using DataBase.QueriesAndCommands.Queries.Functionality;

namespace CommandPanel.Services
{
    public class AccountService
    {
        public AccountMainStatisticViewModel GetAccountMainStatistic(AccountName accountId)
        {
            var context = new ContextFactory().GetContext(accountId);

            var statisticData = new GetLastActivityHistoryRecordQueryHandler(context).Handle(new GetLastActivityHistoryRecordQuery());

            var activityStatistic = new GetFunctionalityStatisticQueryHandler(context).Handle(new GetFunctionalityStatisticQuery());

            return new AccountMainStatisticViewModel
            {
                Name = accountId.ToString("G"),
                AccountId = accountId,
                FollowersCount = statisticData.FollowersCount,
                LastStatisticDate = statisticData.ActivityDateTime,
                Functionalities = activityStatistic.Select(statistic => new FunctionalityMarkerViewModel
                {
                    FunctionalityName = statistic.FunctionalityName,
                    LastActivation = statistic.LastActivity,
                    IsActive = statistic.Token != null
                }).ToList()
            };
        }
    }
}