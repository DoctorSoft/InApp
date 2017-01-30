using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.DefaultData;
using DataBase.Models;

namespace DataBase.GreenShopMigrations
{
    internal sealed class GreenShopConfiguration : DbMigrationsConfiguration<DataBase.Contexts.GreenShopContext>
    {
        public GreenShopConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"GreenShopMigrations";
        }

        protected override void Seed(DataBase.Contexts.GreenShopContext context)
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
                HomePageUrl = "https://www.instagram.com/greenshopping.grodno/",
                Login = "greenshopping.grodno",
                Password = "1ve2ra3",
                ProxyLogin = "eQznhb",
                ProxyPassword = "fbVnXJ",
                Proxy = "81.177.3.188:11574"
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
