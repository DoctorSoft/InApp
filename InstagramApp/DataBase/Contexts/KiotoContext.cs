using Constants;

namespace DataBase.Contexts
{
    public class KiotoContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new KiotoContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Kioto;
        }
    }
}
