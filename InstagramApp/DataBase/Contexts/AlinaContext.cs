using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Alina)]
    public class AlinaContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new AlinaContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Alina;
        }
    }
}
