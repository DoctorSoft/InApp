using Constants;

namespace DataBase.Contexts
{
    public class EgorContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.Egor;
        }
    }
}
