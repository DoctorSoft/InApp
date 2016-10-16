using Constants;

namespace DataBase.Contexts
{
    public class GreenDozorContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.GreenDozor;
        }
    }
}
