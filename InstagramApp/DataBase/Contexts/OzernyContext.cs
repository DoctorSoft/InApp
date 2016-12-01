using Constants;

namespace DataBase.Contexts
{
    public class OzernyContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new OzernyContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Ozerny;
        }
    }
}
