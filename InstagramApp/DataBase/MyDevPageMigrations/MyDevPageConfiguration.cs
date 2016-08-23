using System.Collections.Generic;
using Constants;
using DataBase.Models;

namespace DataBase.MyDevPageMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class MyDevPageConfiguration : DbMigrationsConfiguration<DataBase.Contexts.MyDevPageContext>
    {
        public MyDevPageConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"MyDevPageMigrations";
        }

        protected override void Seed(DataBase.Contexts.MyDevPageContext context)
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

            if (!context.ProfileSettings.Any())
            {
                var settings = new ProfileSettingsDbModel
                {
                    HomePageUrl = "https://www.instagram.com/ozerny/",
                    Login = "Ozerny",
                    Password = "123qazwsxedc890"
                };
                context.ProfileSettings.Add(settings);
            }

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
                }
            };

            context.SpamWords.AddRange(spamWords);
        }
    }
}
