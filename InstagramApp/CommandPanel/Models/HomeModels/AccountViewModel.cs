using Constants;

namespace CommandPanel.Models.HomeModels
{
    public class AccountViewModel
    {
        public string Name { get; set; }

        public AccountName AccountId { get; set; }

        public string ProxyLogin { get; set; }

        public string ProxyPassword { get; set; }

        public long Difference { get; set; }

        public long Followers { get; set; }

        public long Following { get; set; }

        public long UsersToFollow { get; set; }

        public string Url { get; set; }
    }
}