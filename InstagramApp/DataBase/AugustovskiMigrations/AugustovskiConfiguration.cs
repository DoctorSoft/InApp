using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.Models;

namespace DataBase.AugustovskiMigrations
{
    internal sealed class AugustovskiConfiguration : DbMigrationsConfiguration<DataBase.Contexts.AugustovskiContext>
    {
        public AugustovskiConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"AugustovskiMigrations";
        }

        protected override void Seed(DataBase.Contexts.AugustovskiContext context)
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
                HomePageUrl = "https://www.instagram.com/augustovskikanal/",
                Login = "augustovskikanal",
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
                    WordRoot = "сол€р"
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
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.8,
                    WordRoot = "раскрут"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.7,
                    WordRoot = "заказ"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.8,
                    WordRoot = "дилер"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.8,
                    WordRoot = "торг"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.9,
                    WordRoot = "заробот"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.8,
                    WordRoot = "фитнес"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.7,
                    WordRoot = "достав"
                },
                new SpamWordDbModel
                {
                    SpamFactor = 0.8,
                    WordRoot = "тренер"
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
                    Name = "#ћинск"
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
                    Name = "#Ћида"
                },
                new HashTagDbModel
                {
                    Name = "#√родна"
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
                    Name = "#брест"
                },
                new HashTagDbModel
                {
                    Name = "#белосток"
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
                    Name = "#беловежска€пущ€"
                },
                new HashTagDbModel
                {
                    Name = "#августовскийканал"
                },
                new HashTagDbModel
                {
                    Name = "#белорусси€"
                },
                new HashTagDbModel
                {
                    Name = "#белорусь"
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
