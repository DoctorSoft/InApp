using Constants;

namespace DataBase.Contexts
{
    public class LajkiContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new LajkiContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Lajki;
        }
    }
}
