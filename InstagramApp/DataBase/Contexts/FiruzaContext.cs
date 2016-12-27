using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Firuza)]
    public class FiruzaContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new FiruzaContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Firuza;
        }
    }
}
