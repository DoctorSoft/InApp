using Constants;
using Constants.Attributes;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.Etalon)]
    public class EtalonContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new EtalonContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Etalon;
        }
    }
}
