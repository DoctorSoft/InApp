using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Sto2)]
    public class Sto2Context : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new Sto2Context();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Sto2;
        }
    }
}
