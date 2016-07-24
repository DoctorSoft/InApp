using Constants;
using DataBase.Models;

namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataBase.Contexts.DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataBase.Contexts.DataBaseContext context)
        {
            if (!context.Regions.Any())
            {
                var RusLanguage = new LanguageDbModel
                {
                    Name = "Rus"
                };

                var GrodnoRegion = new RegionDbModel
                {
                    Language = RusLanguage,
                    Name = "Grodno",
                    MinX = 23.68,
                    MaxX = 24.02,
                    MinY = 53.60,
                    MaxY = 53.77,
                };

                var S13User = new UserDbModel
                {
                    Language = RusLanguage,
                    ConfirmedByAdmin = true,
                    IncludingTime = DateTime.Now,
                    Link = "https://www.instagram.com/s13.ru/",
                    Region = GrodnoRegion,
                    UserStatus = UserStatus.Technical
                };

                context.Users.Add(S13User);
            }
        }
    }
}
