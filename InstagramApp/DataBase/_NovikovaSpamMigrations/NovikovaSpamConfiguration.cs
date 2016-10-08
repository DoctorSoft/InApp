using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.DefaultData;
using DataBase.Models;

namespace DataBase._NovikovaSpamMigrations
{
    internal sealed class NovikovaSpamConfiguration : DbMigrationsConfiguration<DataBase.Contexts.NovikovaSpamContext>
    {
        public NovikovaSpamConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"_NovikovaSpamMigrations";
        }

        protected override void Seed(DataBase.Contexts.NovikovaSpamContext context)
        {
            if (!context.Users.Any())
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
                HomePageUrl = "https://www.instagram.com/valeryanovikova14/",
                Login = "valeryanovikova14",
                Password = "vn7860002",
                LanguageDetectorKey = "06b11f1ec38eb723b903fc36c74f5fe7"
            };
            context.ProfileSettings.Add(settings);

            context.Languages.RemoveRange(context.Languages);

            var languages = new List<LanguageDbModel>
            {
                new LanguageDbModel
                {
                    Name = "ru"
                },
                new LanguageDbModel
                {
                    Name = "en"
                },
                new LanguageDbModel
                {
                    Name = "pl"
                },
                new LanguageDbModel
                {
                    Name = "uk"
                }
            };

            context.Languages.AddRange(languages);

            context.Features.RemoveRange(context.Features);
            var features = new List<FeaturesDbModel>
            {
                new FeaturesDbModel
                {
                    FeatureIdentyName =  FeaturesName.PostComments.ToString("G"),
                    IsBlocked = true,
                    FeatureIdentity = FeaturesName.PostComments
                },
                new FeaturesDbModel
                {
                    FeatureIdentyName =  FeaturesName.CheckSpammers.ToString("G"),
                    IsBlocked = false,
                    FeatureIdentity = FeaturesName.CheckSpammers
                }
            };
            context.Features.AddRange(features);

            DefaultFunctionalityFiller.FillDefaultFunctionlity(context);
        }
    }
}
