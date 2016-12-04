using System.Data.Entity.Migrations;

namespace DataBase.GalaxyMigrations
{
    internal sealed class GalaxyConfiguration : DbMigrationsConfiguration<DataBase.Contexts.GalaxyContext>
    {
        public GalaxyConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"GalaxyMigrations";
        }

        protected override void Seed(DataBase.Contexts.GalaxyContext context)
        {
            /*if (!context.Users.Any())
            {
                var user = new UserDbModel
                {
                    Link = "https://www.instagram.com/radiosvaboda/",
                    ConfirmedByAdmin = true,
                    IncludingTime = DateTime.Now,
                    UserStatus = UserStatus.Required
                };
                context.Users.Add(user);
            }

            context.ProfileSettings.RemoveRange(context.ProfileSettings);

            var settings = new ProfileSettingsDbModel
            {
                HomePageUrl = "https://www.instagram.com/galaxy.grodno/",
                Login = "galaxy.grodno",
                Password = "Ntvyjnf123",
                LanguageDetectorKey = "06b11f1ec38eb723b903fc36c74f5fe7"
            };
            context.ProfileSettings.Add(settings);
            
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

            DefaultFunctionalityFiller.FillDefaultFunctionlity(context);*/
        }
    }
}
