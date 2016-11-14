using Constants;

namespace DataBase.Contexts
{
    public class EtalonContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.Etalon;
        }
    }
}
