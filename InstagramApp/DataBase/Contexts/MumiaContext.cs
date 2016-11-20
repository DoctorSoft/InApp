using Constants;

namespace DataBase.Contexts
{
    public class MumiaContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.Mumia;
        }
    }
}
