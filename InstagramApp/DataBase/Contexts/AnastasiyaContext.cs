using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Anastasiya)]
    public class AnastasiyaContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new AnastasiyaContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Anastasiya;
        }
    }
}
