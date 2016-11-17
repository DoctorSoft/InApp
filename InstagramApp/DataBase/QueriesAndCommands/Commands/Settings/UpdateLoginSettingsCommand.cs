using Constants;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Settings
{
    public class UpdateLoginSettingsCommand : IVoidCommand
    {
        public AccountName AccountId { get; set; }

        public string Login { get; set; }

        public string HomePage { get; set; }

        public string Password { get; set; }

        public string Proxy { get; set; }

        public string ProxyName { get; set; }

        public string ProxyPassword { get; set; }

        public bool RemoveAllUsers { get; set; }
    }
}
