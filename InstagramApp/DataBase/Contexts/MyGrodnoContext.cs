using Constants;

namespace DataBase.Contexts
{
    public class MyGrodnoContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.MyGrodno;
        }
    }
}
