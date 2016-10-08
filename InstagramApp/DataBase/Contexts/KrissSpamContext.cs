using Constants;

namespace DataBase.Contexts
{
    public class KrissSpamContext: DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.KrissSpam;
        }
    }
}
