using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.Models;

namespace DataBase.DvurechenskyMigrations
{
    internal sealed class DvurechenskyConfiguration : DbMigrationsConfiguration<DataBase.Contexts.DvurechenskyContext>
    {
        public DvurechenskyConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DvurechenskyMigrations";
        }

        protected override void Seed(DataBase.Contexts.DvurechenskyContext context)
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
                HomePageUrl = "https://www.instagram.com/dvurechensky.grodno/",
                Login = "dvurechensky.grodno",
                Password = "Ntvyjnf123",
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
                }
            };

            context.Languages.AddRange(languages);
        }
    }
}
