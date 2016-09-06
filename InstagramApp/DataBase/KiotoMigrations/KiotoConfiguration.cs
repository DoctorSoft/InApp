using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.Models;

namespace DataBase.KiotoMigrations
{
    internal sealed class KiotoConfiguration : DbMigrationsConfiguration<DataBase.Contexts.KiotoContext>
    {
        public KiotoConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"KiotoMigrations";
        }

        protected override void Seed(DataBase.Contexts.KiotoContext context)
        {
            if (!context.Users.Any())
            {
                var user = new UserDbModel
                {
                    Link = "https://www.instagram.com/radiosvaboda/",
                    ConfirmedByAdmin = true,
                    IncludingTime = DateTime.Now,
                    UserStatus = UserStatus.Technical
                };
                context.Users.Add(user);
            }

            context.ProfileSettings.RemoveRange(context.ProfileSettings);
            var settings = new ProfileSettingsDbModel
            {
                HomePageUrl = "https://www.instagram.com/kioto.grodno/",
                Login = "Kioto.grodno",
                Password = "123qazwsxedc890",
                LanguageDetectorKey = "06b11f1ec38eb723b903fc36c74f5fe7"
            };
            context.ProfileSettings.Add(settings);

            context.SpamWords.RemoveRange(context.SpamWords);

            var spamWords = new List<SpamWordDbModel>
            {
                new SpamWordDbModel
                {
                    SpamFactor = 0.9,
                    WordRoot = "реклам"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.8,
                    WordRoot = "услуг"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.9,
                    WordRoot = "скидк"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.9,
                    WordRoot = "оплат"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.7,
                    WordRoot = "издел"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.7,
                    WordRoot = "обуч"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.6,
                    WordRoot = "дизайн"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.6,
                    WordRoot = "достав"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.6,
                    WordRoot = "бизнес"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.6,
                    WordRoot = "ремонт"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.6,
                    WordRoot = "подар"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.7,
                    WordRoot = "соляр"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.6,
                    WordRoot = "тренер"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.9,
                    WordRoot = "прода"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.9,
                    WordRoot = "купл"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.9,
                    WordRoot = "магаз"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.8,
                    WordRoot = "бренд"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.7,
                    WordRoot = "сувенир"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.8,
                    WordRoot = "агенств"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.5,
                    WordRoot = "одежд"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.9,
                    WordRoot = "прокат"
                }
            };

            context.SpamWords.AddRange(spamWords);

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

            context.HashTags.RemoveRange(context.HashTags);

            var hashTags = new List<HashTagDbModel>
            {
                new HashTagDbModel
                {
                    Name = "#Grodno"
                },
                new HashTagDbModel
                {
                    Name = "#кафегродно"
                },
                new HashTagDbModel
                {
                    Name = "#Гродно"
                },
                new HashTagDbModel
                {
                    Name = "#олдситигродно"
                },
                new HashTagDbModel
                {
                    Name = "#Суши"
                },
                new HashTagDbModel
                {
                    Name = "#oldcitygrodno"
                },
                new HashTagDbModel
                {
                    Name = "#OldCity"
                },
                new HashTagDbModel
                {
                    Name = "#евроопт"
                },
                new HashTagDbModel
                {
                    Name = "#едагродно"
                },
                new HashTagDbModel
                {
                    Name = "#lidabeerfest"
                },
            };

            context.HashTags.AddRange(hashTags);

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
        }
    }
}
