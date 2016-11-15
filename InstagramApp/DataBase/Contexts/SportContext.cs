using Constants;

namespace DataBase.Contexts
{
    public class SportContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.Sport;
        }
    }
}
