using Constants;

namespace DataBase.Contexts
{
    public class MirelleContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.Mirelle;
        }
    }
}
