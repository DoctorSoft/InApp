using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.WeHeartGrodno)]
    public class WeHeartGrodnoContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new WeHeartGrodnoContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.WeHeartGrodno;
        }
    }
}
