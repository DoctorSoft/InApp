using Constants;

namespace DataBase.Contexts
{
    public class CanonContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.Canon;
        }
    }
}
