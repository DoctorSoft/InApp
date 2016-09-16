using System;

namespace DataBase.Models
{
    public class ActivityHistoryDbModel
    {
        public long Id { get; set; }

        public DateTime MarkDate { get; set; }

        public long FollowersCount { get; set; }
    }
}
