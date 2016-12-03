using Constants;
using Constants.Attributes;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.NovikovaSpam)]
    public class NovikovaSpamContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new NovikovaSpamContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.NovikovaSpam;
        }
    }
}
