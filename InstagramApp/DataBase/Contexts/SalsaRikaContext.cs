using Constants;
using Constants.Attributes;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.SalsaRika)]
    public class SalsaRikaContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new SalsaRikaContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.SalsaRika;
        }
    }
}
