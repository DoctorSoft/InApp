using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.GadalkaTamara)]
    public class GadalkaTamaraContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new GadalkaTamaraContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.GadalkaTamara;
        }
    }
}
