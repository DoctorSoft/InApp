using Constants;

namespace DataBase.Contexts
{
    public class MirelleContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.Mirelle;
        }
    }
}
