using System;
using System.Collections.Generic;
using Constants;
using DataBase.QueriesAndCommands.Queries.Functionality;

namespace CommandPanel.Models.AccountModels
{
    public class AccountMainStatisticViewModel
    {
        public string Name { get; set; }

        public string PageLink { get; set; }

        public AccountName AccountId { get; set; }

        public DateTime LastStatisticDate { get; set; }

        public long FollowersCount { get; set; }

        public long FollowingsCount { get; set; }

        public long MediaCount { get; set; }

        public long UsersToFollowCount { get; set; }

        public long UsersToDeleteCount { get; set; }

        public long NormalUsersCount { get; set; }

        public List<FunctionalityMarkerViewModel> Functionalities { get; set; }

        public string ChartJsonData { get; set; }

        public FunctionalityReport FunctionalityReport { get; set; }
    }
}