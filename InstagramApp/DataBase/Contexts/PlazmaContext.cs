using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Plazma)]
    public class PlazmaContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new PlazmaContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Plazma;
        }
    }
}
