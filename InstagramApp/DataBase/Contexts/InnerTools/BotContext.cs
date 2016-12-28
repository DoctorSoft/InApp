using Constants;

namespace DataBase.Contexts.InnerTools
{
    public class BotContext : SettingsContext
    {
        private readonly AccountName accountName;
        
        public BotContext(AccountName accountName)
        {
            this.accountName = accountName;
        }

        public override AccountName GetAccountName()
        {
            return accountName;
        }
    }
}
