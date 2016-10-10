using System;
using System.Linq;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.ActivityHistory
{
    public class GetLastActivityHistoryRecordQueryHandler : IQueryHandler<GetLastActivityHistoryRecordQuery, ActivityHistoryModel>
    {
        private readonly DataBaseContext context;

        public GetLastActivityHistoryRecordQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public ActivityHistoryModel Handle(GetLastActivityHistoryRecordQuery query)
        {
            var result = context
                .ActivityHistories
                .OrderByDescending(model => model.MarkDate)
                .Select(model => new ActivityHistoryModel
                {
                    FollowersCount = model.FollowersCount,
                    FollowingsCount = model.FollowingsCount,
                    MediaCount = model.MediaCount,
                    ActivityDateTime = model.MarkDate
                })
                .FirstOrDefault();

            if (result == null)
            {
                return new ActivityHistoryModel
                {
                    FollowersCount = 0,
                    MediaCount = 0,
                    FollowingsCount = 0,
                    ActivityDateTime = DateTime.MinValue
                };
            }

            return result;
        }
    }
}
