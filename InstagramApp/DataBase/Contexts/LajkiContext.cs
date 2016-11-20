using Constants;

namespace DataBase.Contexts
{
    public class LajkiContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.Lajki;
        }
    }
}
