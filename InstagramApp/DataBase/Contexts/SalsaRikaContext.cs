using Constants;

namespace DataBase.Contexts
{
    public class SalsaRikaContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.SalsaRika;
        }
    }
}
