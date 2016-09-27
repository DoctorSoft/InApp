using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.Models;

namespace DataBase.ItransitionMigrations
{
    internal sealed class ItransitionConfiguration : DbMigrationsConfiguration<DataBase.Contexts.ItransitionContext>
    {
        public ItransitionConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"ItransitionMigrations";
        }

        protected override void Seed(DataBase.Contexts.ItransitionContext context)
        {
            /*if (!context.Users.Any())
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
                HomePageUrl = "https://www.instagram.com/_Itransition_/",
                Login = "_Itransition_",
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
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.8,
                    WordRoot = "�������"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.7,
                    WordRoot = "�����"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.8,
                    WordRoot = "�����"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.8,
                    WordRoot = "����"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.9,
                    WordRoot = "�������"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.8,
                    WordRoot = "������"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.7,
                    WordRoot = "������"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.8,
                    WordRoot = "������"
                },
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
                    Name = "#bialystok"
                },new HashTagDbModel
                {
                    Name = "#�����"
                },
                new HashTagDbModel
                {
                    Name = "#minsk"
                },
                new HashTagDbModel
                {
                    Name = "#Polska"
                },
                new HashTagDbModel
                {
                    Name = "#Lida"
                },
                new HashTagDbModel
                {
                    Name = "#����"
                },
                new HashTagDbModel
                {
                    Name = "#������"
                },
                new HashTagDbModel
                {
                    Name = "#Hrodna"
                },
                new HashTagDbModel
                {
                    Name = "#Brest"
                },
                new HashTagDbModel
                {
                    Name = "#�����"
                },
                new HashTagDbModel
                {
                    Name = "#��������"
                },new HashTagDbModel
                {
                    Name = "#vilnius"
                },
                new HashTagDbModel
                {
                    Name = "#Druskininkai"
                },
                new HashTagDbModel
                {
                    Name = "#���������������"
                },
                new HashTagDbModel
                {
                    Name = "#�����������������"
                },
                new HashTagDbModel
                {
                    Name = "#����������"
                },
                new HashTagDbModel
                {
                    Name = "#��������"
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

            context.Functionalities.RemoveRange(context.Functionalities);
            var lastApplied = DateTime.Now - TimeSpan.FromDays(30);
            var functionalities = new List<FunctionalityDbModel>
            {
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.FollowUsers.ToString("G"),
                    FunctionalityNumber = FunctionalityName.FollowUsers,
                    Token = null,
                    ApplyInterval = TimeSpan.FromMinutes(5),
                    ExpectingTime = TimeSpan.FromHours(1),
                },
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.ClearOldMedia.ToString("G"),
                    FunctionalityNumber = FunctionalityName.ClearOldMedia,
                    Token = null,
                    ApplyInterval = TimeSpan.FromHours(12),
                    ExpectingTime = TimeSpan.FromHours(1)
                },
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.LikeMedias.ToString("G"),
                    FunctionalityNumber = FunctionalityName.LikeMedias,
                    Token = null,
                    ApplyInterval = TimeSpan.FromMinutes(5),
                    ExpectingTime = TimeSpan.FromHours(1)
                },
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.SaveMediaByHashTag.ToString("G"),
                    FunctionalityNumber = FunctionalityName.SaveMediaByHashTag,
                    Token = null,
                    ApplyInterval = TimeSpan.FromMinutes(30),
                    ExpectingTime = TimeSpan.FromHours(1)
                },
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.SaveMediaByHomePage.ToString("G"),
                    FunctionalityNumber = FunctionalityName.SaveMediaByHomePage,
                    Token = null,
                    ApplyInterval = TimeSpan.FromMinutes(10),
                    ExpectingTime = TimeSpan.FromHours(1)
                },
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.SearchNewUsers.ToString("G"),
                    FunctionalityNumber = FunctionalityName.SearchNewUsers,
                    Token = null,
                    ApplyInterval = TimeSpan.FromMinutes(15),
                    ExpectingTime = TimeSpan.FromHours(1)
                },
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.SynchOwnerFollowings.ToString("G"),
                    FunctionalityNumber = FunctionalityName.SynchOwnerFollowings,
                    Token = null,
                    ApplyInterval = TimeSpan.FromHours(12),
                    ExpectingTime = TimeSpan.FromHours(2)
                },
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.SynchOwnerFriends.ToString("G"),
                    FunctionalityNumber = FunctionalityName.SynchOwnerFriends,
                    Token = null,
                    ApplyInterval = TimeSpan.FromHours(3),
                    ExpectingTime = TimeSpan.FromHours(2)
                },
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.UnfollowUsers.ToString("G"),
                    FunctionalityNumber = FunctionalityName.UnfollowUsers,
                    Token = null,
                    ApplyInterval = TimeSpan.FromHours(6),
                    ExpectingTime = TimeSpan.FromHours(1)
                },
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.AddComments.ToString("G"),
                    FunctionalityNumber = FunctionalityName.AddComments,
                    Token = null,
                    ApplyInterval = TimeSpan.FromHours(1),
                    ExpectingTime = TimeSpan.FromHours(1)
                },
                new FunctionalityDbModel
                {
                    LastApplied = lastApplied,
                    FunctionalityName = FunctionalityName.AddActivityHistoryMark.ToString("G"),
                    FunctionalityNumber = FunctionalityName.AddActivityHistoryMark,
                    Token = null,
                    ApplyInterval = TimeSpan.FromHours(3),
                    ExpectingTime = TimeSpan.FromHours(1)
                }
            };
            context.Functionalities.AddRange(functionalities);*/
        }
    }
}
