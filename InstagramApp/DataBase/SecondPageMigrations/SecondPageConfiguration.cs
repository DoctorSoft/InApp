using Constants;
using DataBase.Models;

namespace DataBase.SecondPageMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class SecondPageConfiguration : DbMigrationsConfiguration<DataBase.Contexts.SecondPageContext>
    {
        public SecondPageConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"SecondPageMigrations";
        }

        protected override void Seed(DataBase.Contexts.SecondPageContext context)
        {
            if (!context.Users.Any())
            {
                var user = new UserDbModel
                {
                    Link = "https://www.instagram.com/s13.ru/",
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
                    HomePageUrl = "https://www.instagram.com/seconddevpage/",
                    Login = "seconddevpage",
                    Password = "Ntvyjnf123"
                };
                context.ProfileSettings.Add(settings);
            }
        }
    }
}
