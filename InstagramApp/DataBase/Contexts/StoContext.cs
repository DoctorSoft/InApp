using Constants;

namespace DataBase.Contexts
{
    public class StoContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.Sto;
        }
    }
}
