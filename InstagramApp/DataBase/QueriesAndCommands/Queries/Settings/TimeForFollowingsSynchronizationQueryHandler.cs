using System;
using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Settings
{
    public class TimeForFollowingsSynchronizationQueryHandler : IQueryHandler<TimeForFollowingsSynchronizationQuery, bool>
    {
        private readonly DataBaseContext context;

        public TimeForFollowingsSynchronizationQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public bool Handle(TimeForFollowingsSynchronizationQuery query)
        {
            var configs = context.ProfileSettings.FirstOrDefault();

            var prevoiusDate = configs.PreviousFollowingsSynchDate;

            if (prevoiusDate == null)
            {
                return true;
            }

            var now = DateTime.Now;
            var difference = new TimeSpan(1, 0, 0, 0, 0);

            return now - difference > prevoiusDate.Value;
        }
    }
}
