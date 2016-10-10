using System;
using System.Collections.Generic;
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

        public List<FunctionalityMarkerViewModel> Functionalities { get; set; }

        public string ChartJsonData { get; set; }
    }
}