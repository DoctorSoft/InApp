using Constants;

namespace DataBase.Contexts
{
    public class EgorContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new EgorContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Egor;
        }
    }
}
