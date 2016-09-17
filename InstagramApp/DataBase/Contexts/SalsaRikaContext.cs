using Constants;

namespace DataBase.Contexts
{
    public class SalsaRikaContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.SalsaRika;
        }
    }
}
