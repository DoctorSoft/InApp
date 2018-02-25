using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.HappyLadySecret)]
    public class HappyLadySecretContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new HappyLadySecretContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.HappyLadySecret;
        }
    }
}
