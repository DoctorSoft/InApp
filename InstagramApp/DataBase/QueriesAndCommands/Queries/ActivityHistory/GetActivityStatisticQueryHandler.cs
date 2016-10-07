using System.Collections.Generic;
using System.Linq;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.ActivityHistory
{
    public class GetActivityStatisticQueryHandler : IQueryHandler<GetActivityStatisticQuery, List<ActivityStatisticModel>>
    {
        private readonly DataBaseContext context;

        public GetActivityStatisticQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<ActivityStatisticModel> Handle(GetActivityStatisticQuery query)
        {
            var fullStatistic = context
                .ActivityHistories
                .ToList();

            var orderedList = from stat in fullStatistic
                group stat by stat.MarkDate.Date
                into groupedList
                select new ActivityStatisticModel
                {
                    Date = groupedList.Key,
                    Followers = groupedList.Max(model => model.FollowersCount)
                };

            return orderedList
                .OrderByDescending(model => model.Date)
                .Take(query.MaxCount)
                .ToList();
        }
    }
}
