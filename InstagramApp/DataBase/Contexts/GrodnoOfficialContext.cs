using Constants;

namespace DataBase.Contexts
{
    public class GrodnoOfficialContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.GrodnoOfficial;
        }
    }
}
