using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.DefaultData;
using DataBase.Models;

namespace DataBase.MirelleMigrations
{
    internal sealed class MirelleConfiguration : DbMigrationsConfiguration<DataBase.Contexts.MirelleContext>
    {
        public MirelleConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"MirelleMigrations";
        }

        protected override void Seed(DataBase.Contexts.MirelleContext context)
        {
            if (!context.Users.Any())
            {
                var user = new UserDbModel
                {
                    Link = "https://www.instagram.com/radiosvaboda/",
                    ConfirmedByAdmin = true,
                    IncludingTime = DateTime.Now,
                    UserStatus = UserStatus.Required
                };
                context.Users.Add(user);
            }

            context.ProfileSettings.RemoveRange(context.ProfileSettings);
            var settings = new ProfileSettingsDbModel
            {
                HomePageUrl = "https://www.instagram.com/tutbylive/",
                Login = "hair_salon_mirelle",
                Password = "gfhjkm888",
                LanguageDetectorKey = "06b11f1ec38eb723b903fc36c74f5fe7"
            };
            context.ProfileSettings.Add(settings);

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
                    IsBlocked = true,
                    FeatureIdentity = FeaturesName.CheckSpammers
                }
            };
            context.Features.AddRange(features);

            DefaultFunctionalityFiller.FillDefaultFunctionlity(context);
        }
    }
}
