using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.DefaultData;
using DataBase.Models;

namespace DataBase.WeHeartGrodnoMigrations
{
    internal sealed class WeHeartGrodnoConfiguration : DbMigrationsConfiguration<DataBase.Contexts.WeHeartGrodnoContext>
    {
        public WeHeartGrodnoConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"WeHeartGrodnoMigrations";
        }

        protected override void Seed(DataBase.Contexts.WeHeartGrodnoContext context)
        {
            /*if (!context.Users.Any())
            {
                var user = new UserDbModel
                {
                    Link = "https://www.instagram.com/avtominsk/",
                    ConfirmedByAdmin = true,
                    IncludingTime = DateTime.Now,
                    UserStatus = UserStatus.Required
                };
                context.Users.Add(user);
            }*/

            context.ProfileSettings.RemoveRange(context.ProfileSettings);
            var settings = new ProfileSettingsDbModel
            {
                HomePageUrl = "https://www.instagram.com/weheartgrodno/",
                Login = "weheartgrodno",
                Password = "123qazwsxedc890",
                Proxy = "185.66.13.212:11293",
                ProxyLogin = "tNTJKg",
                ProxyPassword = "2ABMkr"
            };
            context.ProfileSettings.Add(settings);

            context.Languages.RemoveRange(context.Languages);

            var languages = new List<LanguageDbModel>
            {
            };

            context.Languages.AddRange(languages);

            context.Features.RemoveRange(context.Features);
            var features = new List<FeaturesDbModel>
            {
                new FeaturesDbModel
                {
                    FeatureIdentyName =  FeaturesName.PostComments.ToString("G"),
                    IsBlocked = true
                },
                new FeaturesDbModel
                {
                    FeatureIdentyName =  FeaturesName.CheckSpammers.ToString("G"),
                    IsBlocked = false
                }
            };
            context.Features.AddRange(features);

            DefaultFunctionalityFiller.FillDefaultFunctionlity(context);
        }
    }
}
