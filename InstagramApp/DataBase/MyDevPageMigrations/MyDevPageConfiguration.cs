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
                    Link = "https://www.instagram.com/s13.ru/",
                    ConfirmedByAdmin = true,
                    IncludingTime = DateTime.Now,
                    UserStatus = UserStatus.Technical
                };
                context.Users.Add(user);
            }
        }
    }
}
