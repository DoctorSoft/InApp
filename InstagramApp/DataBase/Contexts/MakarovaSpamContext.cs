using Constants;
using Constants.Attributes;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.MakarovaSpam)]
    public class MakarovaSpamContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new MakarovaSpamContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.MakarovaSpam;
        }
    }
}
