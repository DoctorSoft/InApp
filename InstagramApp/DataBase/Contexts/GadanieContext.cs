using Constants;

namespace DataBase.Contexts
{
    public class GadanieContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new GadanieContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Gadanie;
        }
    }
}
