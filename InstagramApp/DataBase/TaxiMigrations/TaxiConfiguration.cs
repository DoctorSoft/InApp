using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Constants;
using DataBase.DefaultData;
using DataBase.Models;

namespace DataBase.TaxiMigrations
{
    internal sealed class TaxiConfiguration : DbMigrationsConfiguration<DataBase.Contexts.TaxiContext>
    {
        public TaxiConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"TaxiMigrations";
        }

        protected override void Seed(DataBase.Contexts.TaxiContext context)
        {
            context.ProfileSettings.RemoveRange(context.ProfileSettings);
            var settings = new ProfileSettingsDbModel
            {
                HomePageUrl = "https://www.instagram.com/taxi_vydatnae/",
                Login = "taxi_vydatnae",
                Password = "123AlexVydatniy456",
                ProxyLogin = "fjsKjK",
                ProxyPassword = "yzKGdW",
                Proxy = "217.106.239.97:11641",
                InstagramtId = 4316955164,
                RemoveAllUsers = false,
                FollowingStartHour = 9,
                SwitchingEnabled = false,
                UnfollowingStartHour = 21,
                MaxUsersToFollowCount = 7000,
                MinUsersToFollowCount = 1000
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
