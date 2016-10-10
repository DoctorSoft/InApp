﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using CommandPanel.Models.AccountModels;
using Constants;
using DataBase.Factories;
using DataBase.QueriesAndCommands.Commands.Functionality;
using DataBase.QueriesAndCommands.Commands.Users;
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

            var chart = new GetActivityStatisticQueryHandler(context).Handle(new GetActivityStatisticQuery { MaxCount = 14 });
            var formedChart = chart.Select(model => new ChartData
            {
                Value = model.Followers,
                Day = model.Date.Day,
                Month = model.Date.Month - 1,
                Year = model.Date.Year
            });
            var chartData = new JavaScriptSerializer().Serialize(formedChart);

            return new AccountMainStatisticViewModel
            {
                Name = accountId.ToString("G"),
                AccountId = accountId,
                FollowersCount = statisticData.FollowersCount,
                FollowingsCount = statisticData.FollowingsCount,
                MediaCount = statisticData.MediaCount,
                LastStatisticDate = statisticData.ActivityDateTime,
                Functionalities = activityStatistic.Select(statistic => new FunctionalityMarkerViewModel
                {
                    FunctionalityName = statistic.FunctionalityName,
                    LastActivation = statistic.LastActivity,
                    IsActive = statistic.Token != null,
                    Stopped = statistic.Stopped
                }).ToList(),
                ChartJsonData = chartData
            };
        }

        public void RemoveAllUsersToFollow(AccountName accountId)
        {
            var context = new ContextFactory().GetContext(accountId);

            new RemoveAllUsersToFollowCommandHandler(context).Handle(new RemoveAllUsersToFollowCommand());
        }

        public void SwitchSwitchFunctionalityAccess(AccountName accountId, FunctionalityName functionalityName)
        {
            var context = new ContextFactory().GetContext(accountId);

            new SwitchFunctionalityAccessCommandHandler(context).Handle(new SwitchFunctionalityAccessCommand
            {
                FunctionalityName = functionalityName
            });
        }
    }
}