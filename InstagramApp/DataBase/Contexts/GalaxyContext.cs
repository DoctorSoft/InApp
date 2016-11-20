using Constants;

namespace DataBase.Contexts
{
    public class GalaxyContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.Galaxy;
        }
    }
}
