using Constants;

namespace DataBase.Contexts
{
    public class MirelleContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new MirelleContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Mirelle;
        }
    }
}
