using Constants;

namespace DataBase.Contexts
{
    public class MilkContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.Milk;
        }
    }
}
