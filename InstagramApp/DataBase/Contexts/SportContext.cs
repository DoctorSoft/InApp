using Constants;

namespace DataBase.Contexts
{
    public class SportContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.Sport;
        }
    }
}
