using Constants;

namespace DataBase.Contexts
{
    public class CanonContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new CanonContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Canon;
        }
    }
}
