using Constants;

namespace DataBase.Contexts
{
    public class NazarContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.Nazar;
        }
    }
}
