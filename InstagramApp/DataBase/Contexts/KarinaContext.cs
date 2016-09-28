using Constants;

namespace DataBase.Contexts
{
    public class KarinaContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.Karina;
        }
    }
}
