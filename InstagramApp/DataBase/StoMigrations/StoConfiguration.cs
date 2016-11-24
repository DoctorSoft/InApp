using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using Constants;
using DataBase.DefaultData;
using DataBase.Models;
using DataBase.Models.Content;

namespace DataBase.StoMigrations
{
    internal sealed class StoConfiguration : DbMigrationsConfiguration<DataBase.Contexts.StoContext>
    {
        public StoConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"StoMigrations";
        }

        protected override void Seed(DataBase.Contexts.StoContext context)
        {
            if (!context.Users.Any())
            {
                var user = new UserDbModel
                {
                    Link = "https://www.instagram.com/avtominsk/",
                    ConfirmedByAdmin = true,
                    IncludingTime = DateTime.Now,
                    UserStatus = UserStatus.Required
                };
                context.Users.Add(user);
            }

            context.ProfileSettings.RemoveRange(context.ProfileSettings);
            var settings = new ProfileSettingsDbModel
            {
                HomePageUrl = "https://www.instagram.com/stozapad.by/",
                Login = "stozapad.by",
                Password = "4xAw97GEmKw5",
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
