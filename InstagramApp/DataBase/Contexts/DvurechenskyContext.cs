using Constants;

namespace DataBase.Contexts
{
    public class DvurechenskyContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.Dvurechensky;
        }
    }
}
