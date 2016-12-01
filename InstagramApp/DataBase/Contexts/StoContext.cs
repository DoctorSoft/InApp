using Constants;

namespace DataBase.Contexts
{
    public class StoContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new StoContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Sto;
        }
    }
}
