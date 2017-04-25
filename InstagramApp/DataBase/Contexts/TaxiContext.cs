using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Taxi)]
    public class TaxiContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new TaxiContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Taxi;
        }
    }
}
