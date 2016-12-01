using Constants;

namespace DataBase.Contexts
{
    public class NovikovaSpamContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new NovikovaSpamContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.NovikovaSpam;
        }
    }
}
