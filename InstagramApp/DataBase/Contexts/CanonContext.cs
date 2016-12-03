using Constants;
using Constants.Attributes;

namespace DataBase.Contexts
{
    public class CanonContext : DataBaseContext
    {
        [AccountBase(AccountName = AccountName.Canon)]
        public override DataBaseContext OpenCopyContext()
        {
            return new CanonContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Canon;
        }
    }
}
