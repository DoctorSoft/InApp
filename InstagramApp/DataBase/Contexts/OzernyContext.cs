using Constants;

namespace DataBase.Contexts
{
    public class OzernyContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.Ozerny;
        }
    }
}
