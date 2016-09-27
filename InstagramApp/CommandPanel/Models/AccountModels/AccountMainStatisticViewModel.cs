using System;
using Constants;

namespace CommandPanel.Models.AccountModels
{
    public class AccountMainStatisticViewModel
    {
        public string Name { get; set; }

        public AccountName AccountId { get; set; }

        public DateTime LastStatisticDate { get; set; }

        public long FollowersCount { get; set; }
    }
}