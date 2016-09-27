using CommandPanel.Models.AccountModels;
using Constants;
using DataBase.Factories;
using DataBase.QueriesAndCommands.Queries.ActivityHistory;

namespace CommandPanel.Services
{
    public class AccountService
    {
        public AccountMainStatisticViewModel GetAccountMainStatistic(AccountName accountId)
        {
            var context = new ContextFactory().GetContext(accountId);

            var statisticData = new GetLastActivityHistoryRecordQueryHandler(context).Handle(new GetLastActivityHistoryRecordQuery());

            return new AccountMainStatisticViewModel
            {
                Name = accountId.ToString("G"),
                AccountId = accountId,
                FollowersCount = statisticData.FollowersCount,
                LastStatisticDate = statisticData.ActivityDateTime
            };
        }
    }
}