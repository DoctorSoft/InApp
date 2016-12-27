using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Augustovski)]
    public class AugustovskiContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new AugustovskiContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Augustovski;
        }
    }
}
