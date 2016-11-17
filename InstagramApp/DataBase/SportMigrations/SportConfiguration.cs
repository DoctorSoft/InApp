using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.DefaultData;
using DataBase.Models;

namespace DataBase.SportMigrations
{
    internal sealed class SportConfiguration : DbMigrationsConfiguration<DataBase.Contexts.SportContext>
    {
        public SportConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"SportMigrations";
        }

        protected override void Seed(DataBase.Contexts.SportContext context)
        {
            /*if (!context.Users.Any())
            {
                var user = new UserDbModel
                {
                    Link = "https://www.instagram.com/s13.ru/",
                    ConfirmedByAdmin = true,
                    IncludingTime = DateTime.Now,
                    UserStatus = UserStatus.Required
                };
                context.Users.Add(user);
            }

            context.ProfileSettings.RemoveRange(context.ProfileSettings);
            var settings = new ProfileSettingsDbModel
            {
                HomePageUrl = "https://www.instagram.com/sport.by/",
                Login = "sport.by",
                Password = "harvester1974",
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

            DefaultFunctionalityFiller.FillDefaultFunctionlity(context);*/
        }
    }
}
