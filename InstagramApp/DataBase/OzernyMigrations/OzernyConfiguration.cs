using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.Models;

namespace DataBase.OzernyMigrations
{
    internal sealed class OzernyConfiguration : DbMigrationsConfiguration<DataBase.Contexts.OzernyContext>
    {
        public OzernyConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"OzernyMigrations";
        }

        protected override void Seed(DataBase.Contexts.OzernyContext context)
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
                HomePageUrl = "https://www.instagram.com/ozerny/",
                Login = "Ozerny",
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
                    WordRoot = "������"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.8,
                    WordRoot = "�����"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.9,
                    WordRoot = "�����"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.9,
                    WordRoot = "�����"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.7,
                    WordRoot = "�����"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.7,
                    WordRoot = "����"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.6,
                    WordRoot = "������"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.6,
                    WordRoot = "������"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.6,
                    WordRoot = "������"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.6,
                    WordRoot = "������"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.6,
                    WordRoot = "�����"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.7,
                    WordRoot = "�����"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.6,
                    WordRoot = "������"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.9,
                    WordRoot = "�����"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.9,
                    WordRoot = "����"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.9,
                    WordRoot = "�����"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.8,
                    WordRoot = "�����"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.7,
                    WordRoot = "�������"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.8,
                    WordRoot = "�������"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.5,
                    WordRoot = "�����"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.9,
                    WordRoot = "������"
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
                    Name = "#��������"
                },
                new HashTagDbModel
                {
                    Name = "#Belarus"
                },
                new HashTagDbModel
                {
                    Name = "#������2016"
                },
                new HashTagDbModel
                {
                    Name = "#����������"
                },
                new HashTagDbModel
                {
                    Name = "#����������"
                },
                new HashTagDbModel
                {
                    Name = "#�����������"
                },
                new HashTagDbModel
                {
                    Name = "#��������������"
                },
                new HashTagDbModel
                {
                    Name = "#grodnonow"
                },
                new HashTagDbModel
                {
                    Name = "#grodno24"
                },
            };

            context.HashTags.AddRange(hashTags);

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
                    IsBlocked = true
                }
            };
            context.Features.AddRange(features);
        }
    }
}
