using Constants;
using Constants.Attributes;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Galaxy)]
    public class GalaxyContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new GalaxyContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Galaxy;
        }
    }
}
