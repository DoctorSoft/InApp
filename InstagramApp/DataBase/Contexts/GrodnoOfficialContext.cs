using Constants;

namespace DataBase.Contexts
{
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
