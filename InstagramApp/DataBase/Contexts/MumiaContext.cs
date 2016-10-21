using Constants;

namespace DataBase.Contexts
{
    public class MumiaContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.Mumia;
        }
    }
}
