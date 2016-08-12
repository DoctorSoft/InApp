using Constants;

namespace DataBase.Contexts
{
    public class MyDevPageContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.MyDevPage;
        }
    }
}
