using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Settings
{
    public class GetProfileSettingsQueryHandler : IQueryHandler<GetProfileSettingsQuery, ProfileSettingsDbModel>
    {
        private readonly DataBaseContext context;
        public GetProfileSettingsQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }
        public ProfileSettingsDbModel Handle(GetProfileSettingsQuery query)
        {
            ProfileSettingsDbModel profile = context
            .ProfileSettings
            .FirstOrDefault();

            return profile;
        }
    }
}
