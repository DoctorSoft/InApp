using Constants;

namespace DataBase.Contexts
{
    public class EtalonContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.Etalon;
        }
    }
}
