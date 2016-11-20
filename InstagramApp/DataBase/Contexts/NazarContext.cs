using Constants;

namespace DataBase.Contexts
{
    public class NazarContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.Nazar;
        }
    }
}
