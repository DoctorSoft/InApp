namespace DataBase.Models
{
    public class ProfileSettingsDbModel
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string HomePageUrl { get; set; }

        public string LanguageDetectorKey { get; set; }
    }
}
