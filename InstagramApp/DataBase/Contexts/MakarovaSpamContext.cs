using Constants;

namespace DataBase.Contexts
{
    public class MakarovaSpamContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new MakarovaSpamContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.MakarovaSpam;
        }
    }
}
