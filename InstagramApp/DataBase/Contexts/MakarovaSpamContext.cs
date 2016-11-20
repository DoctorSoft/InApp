using Constants;

namespace DataBase.Contexts
{
    public class MakarovaSpamContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.MakarovaSpam;
        }
    }
}
