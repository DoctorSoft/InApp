using Constants;

namespace DataBase.Contexts
{
    public class SalsaRikaContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new SalsaRikaContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.SalsaRika;
        }
    }
}
