using Constants;

namespace DataBase.Contexts
{
    public class LajkiContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.Lajki;
        }
    }
}
