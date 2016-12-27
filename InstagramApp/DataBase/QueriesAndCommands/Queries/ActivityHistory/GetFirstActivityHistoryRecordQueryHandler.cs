using System;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.ActivityHistory
{
    public class GetFirstActivityHistoryRecordQueryHandler : IQueryHandler<GetFirstActivityHistoryRecordQuery, ActivityHistoryModel>
    {
        private readonly DataBaseContext context;

        public GetFirstActivityHistoryRecordQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public ActivityHistoryModel Handle(GetFirstActivityHistoryRecordQuery query)
        {
            var normalUsers = context.Users.Count(model => model.UserStatus == UserStatus.Normal);

            var result = context
                .ActivityHistories
                .OrderBy(model => model.MarkDate)
                .Select(model => new ActivityHistoryModel
                {
                    FollowersCount = model.FollowersCount,
                    FollowingsCount = model.FollowingsCount,
                    MediaCount = model.MediaCount,
                    ActivityDateTime = model.MarkDate,
                    NormalUesrsCount = normalUsers
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
