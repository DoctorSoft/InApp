using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.DefaultData;
using DataBase.Models;

namespace DataBase.AxFitnessMigrations
{
    internal sealed class AxFitnessConfiguration : DbMigrationsConfiguration<DataBase.Contexts.AxFitnessContext>
    {
        public AxFitnessConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"AxFitnessMigrations";
        }

        protected override void Seed(DataBase.Contexts.AxFitnessContext context)
        {
            context.ProfileSettings.RemoveRange(context.ProfileSettings);
            var settings = new ProfileSettingsDbModel
            {
                HomePageUrl = "https://www.instagram.com/ax.fitness.grodno/",
                Login = "ax.fitness.grodno",
                Password = "123OlgaVaschilo456",
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
