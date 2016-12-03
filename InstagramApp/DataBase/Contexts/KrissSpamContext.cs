using Constants;
using Constants.Attributes;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.KrissSpam)]
    public class KrissSpamContext: DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new KrissSpamContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.KrissSpam;
        }
    }
}
