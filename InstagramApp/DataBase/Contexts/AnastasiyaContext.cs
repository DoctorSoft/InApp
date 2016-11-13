using Constants;

namespace DataBase.Contexts
{
    public class AnastasiyaContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.Anastasiya;
        }
    }
}
