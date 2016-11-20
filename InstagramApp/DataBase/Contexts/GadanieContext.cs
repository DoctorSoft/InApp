using Constants;

namespace DataBase.Contexts
{
    public class GadanieContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.Gadanie;
        }
    }
}
