using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Ozerny)]
    public class OzernyContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new OzernyContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Ozerny;
        }
    }
}
