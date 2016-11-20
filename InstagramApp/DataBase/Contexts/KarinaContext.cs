using Constants;

namespace DataBase.Contexts
{
    public class KarinaContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.Karina;
        }
    }
}
