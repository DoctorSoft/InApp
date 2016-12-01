using Constants;

namespace DataBase.Contexts
{
    public class GalaxyContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new GalaxyContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Galaxy;
        }
    }
}
