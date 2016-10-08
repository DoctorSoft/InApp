using Constants;

namespace DataBase.Contexts
{
    public class NovikovaSpamContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.NovikovaSpam;
        }
    }
}
