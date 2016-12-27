using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Kioto)]
    public class KiotoContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new KiotoContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Kioto;
        }
    }
}
