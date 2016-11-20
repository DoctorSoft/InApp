using Constants;

namespace DataBase.Contexts
{
    public class NovikovaSpamContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.NovikovaSpam;
        }
    }
}
