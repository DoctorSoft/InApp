using Constants;

namespace DataBase.Contexts
{
    public class SecondPageContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.SecondPage;
        }
    }
}
