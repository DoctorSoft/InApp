using Constants;

namespace DataBase.Contexts
{
    public class AnastasiyaContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.Anastasiya;
        }
    }
}
