using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.MKGrodno)]
    public class MKGrodnoContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new MKGrodnoContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.MKGrodno;
        }
    }
}
