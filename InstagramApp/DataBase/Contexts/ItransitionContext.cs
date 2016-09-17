using Constants;

namespace DataBase.Contexts
{
    public class ItransitionContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.Itransition;
        }
    }
}
