using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.DefaultData;
using DataBase.Models;

namespace DataBase.EgorMigrations
{
    internal sealed class EgorConfiguration : DbMigrationsConfiguration<DataBase.Contexts.EgorContext>
    {
        public EgorConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"EgorMigrations";
        }

        protected override void Seed(DataBase.Contexts.EgorContext context)
        {
            if (!context.Users.Any())
            {
                var user = new UserDbModel
                {
                    Link = "https://www.instagram.com/tutbylive/",
                    ConfirmedByAdmin = true,
                    IncludingTime = DateTime.Now,
                    UserStatus = UserStatus.Required
                };
                context.Users.Add(user);
            }

            context.ProfileSettings.RemoveRange(context.ProfileSettings);
            var settings = new ProfileSettingsDbModel
            {
                HomePageUrl = "https://www.instagram.com/tytyuk_egor/",
                Login = "tytyuk_egor",
                Password = "1756350Egor",
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
