using Constants;

namespace DataBase.Contexts
{
    public class KiotoContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.Kioto;
        }
    }
}
