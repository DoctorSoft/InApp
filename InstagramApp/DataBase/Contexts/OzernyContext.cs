using Constants;

namespace DataBase.Contexts
{
    public class OzernyContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.Ozerny;
        }
    }
}
