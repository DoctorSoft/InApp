using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Constants;
using DataBase.DefaultData;
using DataBase.Models;

namespace DataBase.MKGrodnoMigrations
{
    internal sealed class MKGrodnoConfiguration : DbMigrationsConfiguration<DataBase.Contexts.MKGrodnoContext>
    {
        public MKGrodnoConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"MKGrodnoMigrations";
        }

        protected override void Seed(DataBase.Contexts.MKGrodnoContext context)
        {
            /*context.ProfileSettings.RemoveRange(context.ProfileSettings);
            var settings = new ProfileSettingsDbModel
            {
                HomePageUrl = "https://www.instagram.com/grodno_mk/",
                Login = "grodno_mk",
                Password = "mark111",
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

            DefaultFunctionalityFiller.FillDefaultFunctionlity(context);*/
        }
    }
}
