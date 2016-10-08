using Constants;

namespace DataBase.Contexts
{
    public class MakarovaSpamContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.MakarovaSpam;
        }
    }
}
