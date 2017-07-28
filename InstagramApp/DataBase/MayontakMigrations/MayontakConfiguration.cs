using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using DataBase.Models.Content;

namespace DataBase.MayontakMigrations
{
    internal sealed class MayontakConfiguration : DbMigrationsConfiguration<DataBase.Contexts.MayontakContext>
    {
        public MayontakConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"MayontakMigrations";
        }

        protected override void Seed(DataBase.Contexts.MayontakContext context)
        {
            /*if (!context.Users.Any())
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
                HomePageUrl = "https://www.instagram.com/Mayontak.grodno/",
                Login = "Mayontak.grodno",
                Password = "123qazwsxedc890",
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

            DefaultFunctionalityFiller.FillDefaultFunctionlity(context);*/

            var colours = Enum.GetValues(typeof (KnownColor)).Cast<KnownColor>().Select(color => new ColourDbModel
            {
                Name = color.ToString("G")
            });

            context.Colours.AddRange(colours);

            var contentTypes = new List<string>()
            {
                "Food", "People", "Place", "Decoration", 
            }.Select(s => new ContentTypeDbModel
            {
                Name = s,
            });

            context.ContentTypes.AddRange(contentTypes);
        }
    }
}
