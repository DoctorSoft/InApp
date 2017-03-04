namespace CommandPanel.Models.ConfigurationsModels
{
    public class ConfigurationsDraftModel
    {
        public string Login { get; set; }

        public string HomePage { get; set; }

        public string Password { get; set; }

        public string Proxy { get; set; }

        public string ProxyName { get; set; }

        public string ProxyPassword { get; set; }

        public bool RemoveAllUsers { get; set; }

        public string InstagramId { get; set; }

        public bool SwitchingEnabled { get; set; }

        public int FollowingStartHour { get; set; }

        public int UnfollowingStartHour { get; set; }

        public int MinUsersToFollowCount { get; set; }

        public int MaxUsersToFollowCount { get; set; }
    }
}