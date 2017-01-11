using System;
using System.Data.Entity;
using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;
using LikeBotMigrator;

namespace DataBase.QueriesAndCommands.Queries.Settings
{
    public class GetProfileSettingsQueryHandler : IQueryHandler<GetProfileSettingsQuery, ProfileSettingsDbModel>
    {
        private readonly ISettingsContext context;

        public GetProfileSettingsQueryHandler(ISettingsContext context)
        {
            this.context = context;
        }

        public ProfileSettingsDbModel Handle(GetProfileSettingsQuery query)
        {
            var profile = context.ProfileSettings.FirstOrDefault();
            
            if (profile == null)
            {
                return new ProfileSettingsDbModel
                {
                    Proxy = "",
                    RemoveAllUsers = false,
                    Id = 0,
                    ProxyPassword = "",
                    ProxyLogin = "",
                    PreviousFollowingsSynchDate = null,
                    Password = "",
                    HomePageUrl = "",
                    Login = "",
                    Cookies = "",
                    InstagramtId = 0
                };
            }

            return profile;
        }
    }
}
