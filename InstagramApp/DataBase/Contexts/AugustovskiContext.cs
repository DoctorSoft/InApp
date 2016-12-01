using Constants;

namespace DataBase.Contexts
{
    public class AugustovskiContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new AugustovskiContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Augustovski;
        }
    }
}
