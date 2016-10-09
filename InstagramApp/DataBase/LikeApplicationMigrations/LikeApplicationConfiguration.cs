using System.Collections.Generic;
using System.Data.Entity.Migrations;
using DataBase.Contexts.LikeApplication;
using DataBase.Models.LikeApplication;

namespace DataBase.LikeApplicationMigrations
{
    internal sealed class LikeApplicationConfiguration : DbMigrationsConfiguration<LikeApplicationContext>
    {
        public LikeApplicationConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"LikeApplicationMigrations";
        }

        protected override void Seed(LikeApplicationContext context)
        {
            var accounts = new List<LikeAccountDbModel>
            {
                new LikeAccountDbModel
                {
                    Name = "denispetrovgrodno",
                    Email = "ArcherFromGrodno+Grodno@gmail.com",
                    Link = "https://www.instagram.com/denispetrovgrodno/",
                    Password = "GrodnoGrodno"
                },
                new LikeAccountDbModel
                {
                    Name = "sulimabrest",
                    Email = "ArcherFromGrodno+Brest@gmail.com",
                    Link = "https://www.instagram.com/sulimabrest/",
                    Password = "GrodnoGrodno"
                },
                new LikeAccountDbModel
                {
                    Name = "titgomel",
                    Email = "ArcherFromGrodno+Gomel@gmail.com",
                    Link = "https://www.instagram.com/titgomel/",
                    Password = "GrodnoGrodno"
                },
                new LikeAccountDbModel
                {
                    Name = "bondarevaemma",
                    Email = "vasiliyivanchuk10@gmail.com",
                    Link = "https://www.instagram.com/bondarevaemma/",
                    Password = "jylfhtdf123"
                },
                new LikeAccountDbModel
                {
                    Name = "eseninabronislava",
                    Email = "vasiliyivanchuk10+1@gmail.com",
                    Link = "https://www.instagram.com/eseninabronislava/",
                    Password = "hjybckfdf123"
                },
                new LikeAccountDbModel
                {
                    Name = "jernakovsergey",
                    Email = "vasiliyivanchuk10+2@gmail.com",
                    Link = "https://www.instagram.com/jernakovsergey/",
                    Password = "thyfrjd123"
                },
                new LikeAccountDbModel
                {
                    Name = "nikandrovdenis",
                    Email = "vasiliyivanchuk10+3@gmail.com",
                    Link = "https://www.instagram.com/nikandrovdenis/",
                    Password = "brfylhjd123"
                },
                new LikeAccountDbModel
                {
                    Name = "iandutkinanina",
                    Email = "vasiliyivanchuk10+4@gmail.com",
                    Link = "https://www.instagram.com/iandutkinanina/",
                    Password = "lenrbyf123"
                },
            };

            context.Accounts.AddRange(accounts);
        }
    }
}
