using Constants;

namespace DataBase.Contexts
{
    public class KiotoContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.Kioto;
        }
    }
}
