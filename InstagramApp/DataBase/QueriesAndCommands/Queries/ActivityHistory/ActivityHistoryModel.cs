using System;

namespace DataBase.QueriesAndCommands.Queries.ActivityHistory
{
    public class ActivityHistoryModel
    {
        public DateTime ActivityDateTime { get; set; }

        public long FollowersCount { get; set; }

        public long FollowingsCount { get; set; }

        public long MediaCount { get; set; }
    }
}
