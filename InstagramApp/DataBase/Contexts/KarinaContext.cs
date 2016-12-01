using Constants;

namespace DataBase.Contexts
{
    public class KarinaContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new KarinaContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Karina;
        }
    }
}
