using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.GrodnoOfficial)]
    public class GrodnoOfficialContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new GrodnoOfficialContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.GrodnoOfficial;
        }
    }
}
