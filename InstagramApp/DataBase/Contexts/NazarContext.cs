using Constants;
using Constants.Attributes;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Nazar)]
    public class NazarContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new NazarContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Nazar;
        }
    }
}
