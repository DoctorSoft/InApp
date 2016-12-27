using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Sport)]
    public class SportContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new SportContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Sport;
        }
    }
}
