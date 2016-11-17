using System;

namespace DataBase.Models
{
    public class ProfileSettingsDbModel
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string HomePageUrl { get; set; }

        public DateTime? PreviousFollowingsSynchDate { get; set; }

        public string Proxy { get; set; }

        public string ProxyLogin { get; set; }

        public string ProxyPassword { get; set; }

        public bool RemoveAllUsers { get; set; }
    }
}
