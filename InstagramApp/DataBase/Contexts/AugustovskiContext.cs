using Constants;

namespace DataBase.Contexts
{
    public class AugustovskiContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.Augustovski;
        }
    }
}
