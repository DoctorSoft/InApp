using Constants;
using Constants.Attributes;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Lajki)]
    public class LajkiContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new LajkiContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Lajki;
        }
    }
}
