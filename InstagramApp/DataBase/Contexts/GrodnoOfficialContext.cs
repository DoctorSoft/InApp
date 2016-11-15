using Constants;

namespace DataBase.Contexts
{
    public class GrodnoOfficialContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.GrodnoOfficial;
        }
    }
}
