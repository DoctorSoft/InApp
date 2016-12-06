using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.DefaultData;
using DataBase.Models;

namespace DataBase.KeratinMigrations
{
    internal sealed class KeratinConfiguration : DbMigrationsConfiguration<DataBase.Contexts.KeratinContext>
    {
        public KeratinConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"KeratinMigrations";
        }

        protected override void Seed(DataBase.Contexts.KeratinContext context)
        {
            if (!context.Users.Any())
            {
                var user = new UserDbModel
                {
                    Link = "https://www.instagram.com/grodnonow/",
                    ConfirmedByAdmin = true,
                    IncludingTime = DateTime.Now,
                    UserStatus = UserStatus.Required
                };
                context.Users.Add(user);
            }

            context.ProfileSettings.RemoveRange(context.ProfileSettings);
            var settings = new ProfileSettingsDbModel
            {
                HomePageUrl = "https://www.instagram.com/keratin_wonderful.grodno/",
                Login = "keratin_wonderful.grodno",
                Password = "lika12345",
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
