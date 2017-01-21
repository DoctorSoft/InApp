using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using Constants;
using DataBase.DefaultData;
using DataBase.Models;
using DataBase.Models.Content;

namespace DataBase.SystemDoctorMigrations
{
    internal sealed class SystemDoctorConfiguration : DbMigrationsConfiguration<DataBase.Contexts.SystemDoctorContext>
    {
        public SystemDoctorConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"SystemDoctorMigrations";
        }

        protected override void Seed(DataBase.Contexts.SystemDoctorContext context)
        {
            if (!context.Users.Any())
            {
                var user = new UserDbModel
                {
                    Link = "https://www.instagram.com/vrangeltv/",
                    ConfirmedByAdmin = true,
                    IncludingTime = DateTime.Now,
                    UserStatus = UserStatus.Required
                };
                context.Users.Add(user);
            }

            context.ProfileSettings.RemoveRange(context.ProfileSettings);
            var settings = new ProfileSettingsDbModel
            {
                HomePageUrl = "https://www.instagram.com/systemdoctor/",
                Login = "systemdoctor",
                Password = "harvester19748888874"
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
