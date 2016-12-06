using Constants;
using Constants.Attributes;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Keratin)]
    public class KeratinContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new KeratinContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Keratin;
        }
    }
}
