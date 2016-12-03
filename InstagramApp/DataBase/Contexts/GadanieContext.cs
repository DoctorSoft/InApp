using Constants;
using Constants.Attributes;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Gadanie)]
    public class GadanieContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new GadanieContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Gadanie;
        }
    }
}
