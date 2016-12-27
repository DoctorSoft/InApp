using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.MyGrodno)]
    public class MyGrodnoContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new MyGrodnoContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.MyGrodno;
        }
    }
}
