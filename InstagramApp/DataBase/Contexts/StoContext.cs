using Constants;
using Constants.Attributes;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Sto)]
    public class StoContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new StoContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Sto;
        }
    }
}
