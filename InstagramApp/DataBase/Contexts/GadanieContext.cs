using Constants;

namespace DataBase.Contexts
{
    public class GadanieContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.Gadanie;
        }
    }
}
