using Constants;

namespace DataBase.Contexts
{
    public class MyGrodnoContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.MyGrodno;
        }
    }
}
