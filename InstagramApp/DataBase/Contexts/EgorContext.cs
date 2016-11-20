using Constants;

namespace DataBase.Contexts
{
    public class EgorContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.Egor;
        }
    }
}
