using Constants;
using Constants.Attributes;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Mumia)]
    public class MumiaContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new MumiaContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Mumia;
        }
    }
}
