using Constants;

namespace DataBase.Contexts
{
    public class CanonContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.Canon;
        }
    }
}
