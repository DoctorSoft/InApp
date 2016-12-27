using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Karina)]
    public class KarinaContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new KarinaContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Karina;
        }
    }
}
