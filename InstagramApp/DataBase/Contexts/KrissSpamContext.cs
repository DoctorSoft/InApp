using Constants;

namespace DataBase.Contexts
{
    public class KrissSpamContext: DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new KrissSpamContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.KrissSpam;
        }
    }
}
