using Constants;
using Constants.Attributes;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.GreenDozor)]
    public class GreenDozorContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new GreenDozorContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.GreenDozor;
        }
    }
}
