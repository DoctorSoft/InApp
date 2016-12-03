using Constants;
using Constants.Attributes;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Mirelle)]
    public class MirelleContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new MirelleContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Mirelle;
        }
    }
}
