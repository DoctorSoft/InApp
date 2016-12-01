using Constants;

namespace DataBase.Contexts
{
    public class MyGrodnoContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new MyGrodnoContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.MyGrodno;
        }
    }
}
