using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq.Dynamic;
using Constants;
using DataBase.DefaultData;
using DataBase.Models;

namespace DataBase.Sto2Migrations
{
    internal sealed class Sto2Configuration : DbMigrationsConfiguration<DataBase.Contexts.Sto2Context>
    {
        public Sto2Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Sto2Migrations";
        }

        protected override void Seed(DataBase.Contexts.Sto2Context context)
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
                HomePageUrl = "https://www.instagram.com/Salonprokat/",
                Login = "Salonprokat",
                Password = "Ntvyjnf123",
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
