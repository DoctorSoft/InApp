using System.Linq;
using System.Web.Script.Serialization;
using CommandPanel.Models.AccountModels;
using Constants;
using DataBase.QueriesAndCommands.Commands.Functionality;
using DataBase.QueriesAndCommands.Commands.Users;
using DataBase.QueriesAndCommands.Queries.ActivityHistory;
using DataBase.QueriesAndCommands.Queries.Functionality;
using DataBase.QueriesAndCommands.Queries.Settings;
using DataBase.QueriesAndCommands.Queries.Users;
using Tools.Factories;

namespace CommandPanel.Services
{
    public class AccountService
    {
        public AccountMainStatisticViewModel GetAccountMainStatistic(AccountName accountId)
        {
            var context = new ContextFactory().GetContext(accountId);

            var statisticData = new GetLastActivityHistoryRecordQueryHandler(context).Handle(new GetLastActivityHistoryRecordQuery());

            var activityStatistic = new GetFunctionalityStatisticQueryHandler(context).Handle(new GetFunctionalityStatisticQuery());

            var settings = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());

            var userProcessingStatistic = new GetUserProcessingStatisticQueryHandler(context).Handle(new GetUserProcessingStatisticQuery
            {
                RemoveAllUsers = settings.RemoveAllUsers
            });

            var configs = new GetProfileSettingsQueryHandler(context).Handle(new GetProfileSettingsQuery());

            var chart = new GetActivityStatisticQueryHandler(context).Handle(new GetActivityStatisticQuery { MaxCount = 14 });
            var formedChart = chart.Select(model => new ChartData
            {
                Value = model.Followers,
                Day = model.Date.Day,
                Month = model.Date.Month - 1,
                Year = model.Date.Year
            });
            var chartData = new JavaScriptSerializer().Serialize(formedChart);

            var report = new GetLastReportQueryHandler(context).Handle(new GetLastReportQuery());

            return new AccountMainStatisticViewModel
            {
                Name = accountId.ToString("G"),
                PageLink = configs.HomePageUrl,
                AccountId = accountId,
                FollowersCount = statisticData.FollowersCount,
                FollowingsCount = statisticData.FollowingsCount,
                MediaCount = statisticData.MediaCount,
                UsersToDeleteCount = userProcessingStatistic.UsersToDeleteCount,
                UsersToFollowCount = userProcessingStatistic.UsersToFollowCount,
                NormalUsersCount = statisticData.NormalUesrsCount,
                LastStatisticDate = statisticData.ActivityDateTime,
                Functionalities = activityStatistic.Select(statistic => new FunctionalityMarkerViewModel
                {
                    FunctionalityName = statistic.FunctionalityName,
                    LastActivation = statistic.LastActivity,
                    IsActive = statistic.Token != null,
                    Stopped = statistic.Stopped,
                    Asap = statistic.Asap
                }).ToList(),
                ChartJsonData = chartData,
                FunctionalityReport = report
            };
        }

        public void RemoveAllUsersToFollow(AccountName accountId)
        {
            var context = new ContextFactory().GetContext(accountId);

            new RemoveAllUsersByStatusCommandHandler(context).Handle(new RemoveAllUsersByStatusCommand { UserStatus = UserStatus.ToFollow });
        }

        public void RemoveAllNormalUsers(AccountName accountId)
        {
            var context = new ContextFactory().GetContext(accountId);

            new RemoveAllUsersByStatusCommandHandler(context).Handle(new RemoveAllUsersByStatusCommand { UserStatus = UserStatus.Normal });
        }

        public void RemoveAllUsersToDelete(AccountName accountId)
        {
            var context = new ContextFactory().GetContext(accountId);

            new RemoveAllUsersByStatusCommandHandler(context).Handle(new RemoveAllUsersByStatusCommand { UserStatus = UserStatus.ToDelete });
        }

        public void SwitchFunctionalityAccess(AccountName accountId, FunctionalityName functionalityName)
        {
            var context = new ContextFactory().GetContext(accountId);

            new SwitchFunctionalityAccessCommandHandler(context).Handle(new SwitchFunctionalityAccessCommand
            {
                FunctionalityName = functionalityName
            });
        }

        public void SetFunctionalityAsAsap(AccountName accountId, FunctionalityName functionalityName)
        {
            var context = new ContextFactory().GetContext(accountId);
            new SetFunctionalityAsAsapCommandHandler(context).Handle(new SetFunctionalityAsAsapCommand
            {
                FunctionalityName = functionalityName
            });
        }

        public void ClearAccountLogs(AccountName accountId)
        {
            var context = new ContextFactory().GetContext(accountId);
            new ClearFunctionalityRecordsCommandHandler(context).Handle(new ClearFunctionalityRecordsCommand());
        }

        public void ResetAllSearchFriendsMarks(AccountName accountId)
        {
            var context = new ContextFactory().GetContext(accountId);
            new ResetAllSearchFriendsMarksCommandHandler(context).Handle(new ResetAllSearchFriendsMarksCommand());
        }

        public void ResetAllFunctionalityTokens(AccountName accountId)
        {
            var context = new ContextFactory().GetContext(accountId);
            new ResetAllFunctionalityTokensCommandHandler(context).Handle(new ResetAllFunctionalityTokensCommand());
        }

        public void MakeFunctionalityReport(AccountName accountId)
        {
            var context = new ContextFactory().GetContext(accountId);
            new MakeFunctionalityReportCommandHandler(context).Handle(new MakeFunctionalityReportCommand());
        }
    }
}