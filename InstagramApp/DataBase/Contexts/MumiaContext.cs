using Constants;

namespace DataBase.Contexts
{
    public class MumiaContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new MumiaContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Mumia;
        }
    }
}
