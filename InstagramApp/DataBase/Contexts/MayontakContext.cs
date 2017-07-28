using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Mayontak)]
    public class MayontakContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new MayontakContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Mayontak;
        }
    }
}
