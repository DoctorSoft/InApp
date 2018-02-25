using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Karina2)]
    public class Karina2Context : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new Karina2Context();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Karina2;
        }
    }
}
