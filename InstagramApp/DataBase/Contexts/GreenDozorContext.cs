using Constants;

namespace DataBase.Contexts
{
    public class GreenDozorContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.GreenDozor;
        }
    }
}
