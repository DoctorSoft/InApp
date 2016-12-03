using Constants;
using Constants.Attributes;

namespace DataBase.Contexts
{
    public class EgorContext : DataBaseContext
    {
        [AccountBase(AccountName = AccountName.Egor)]
        public override DataBaseContext OpenCopyContext()
        {
            return new EgorContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Egor;
        }
    }
}
