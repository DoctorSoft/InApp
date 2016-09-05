using Constants;

namespace DataBase.Contexts
{
    public class GalaxyContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.Galaxy;
        }
    }
}
