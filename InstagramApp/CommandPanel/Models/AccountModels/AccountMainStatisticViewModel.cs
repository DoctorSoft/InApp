using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Constants;

namespace CommandPanel.Models.AccountModels
{
    public class AccountMainStatisticViewModel
    {
        public string Name { get; set; }

        public AccountName AccountId { get; set; }

        public DateTime LastStatisticDate { get; set; }

        public long FollowersCount { get; set; }

        public long FollowingsCount { get; set; }

        public long MediaCount { get; set; }

        public long UsersToFollowCount { get; set; }

        public long UsersToDeleteCount { get; set; }

        public long PoorFollowersCount { get; set; }

        public List<FunctionalityMarkerViewModel> Functionalities { get; set; }

        public string ChartJsonData { get; set; }
    }
}