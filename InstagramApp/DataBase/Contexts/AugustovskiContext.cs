using Constants;

namespace DataBase.Contexts
{
    public class AugustovskiContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.Augustovski;
        }
    }
}
