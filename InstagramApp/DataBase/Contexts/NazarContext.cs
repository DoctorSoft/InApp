using Constants;

namespace DataBase.Contexts
{
    public class NazarContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new NazarContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Nazar;
        }
    }
}
