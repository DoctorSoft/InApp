using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.DefaultData;
using DataBase.Models;

namespace DataBase.MogilevTurismMigrations
{
    internal sealed class MogilevTurismConfiguration : DbMigrationsConfiguration<DataBase.Contexts.MogilevTurismContext>
    {
        public MogilevTurismConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"MogilevTurismMigrations";
        }

        protected override void Seed(DataBase.Contexts.MogilevTurismContext context)
        {
            if (!context.Users.Any())
            {
                var user = new UserDbModel
                {
                    Link = "https://www.instagram.com/mogilevoblturist/",
                    ConfirmedByAdmin = true,
                    IncludingTime = DateTime.Now,
                    UserStatus = UserStatus.Required
                };
                context.Users.Add(user);
            }

            context.ProfileSettings.RemoveRange(context.ProfileSettings);
            var settings = new ProfileSettingsDbModel
            {
                HomePageUrl = "https://www.instagram.com/mogilevoblturist/",
                Login = "mogilevoblturist",
                Password = "heyapple1",
                ProxyLogin = "rcBn9f",
                ProxyPassword = "eSuCjW",
                Proxy = "217.29.53.106:14411"
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
