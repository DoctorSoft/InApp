using Constants;

namespace DataBase.Contexts
{
    public class KrissSpamContext: DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.KrissSpam;
        }
    }
}
