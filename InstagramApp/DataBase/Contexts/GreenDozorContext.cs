using Constants;

namespace DataBase.Contexts
{
    public class GreenDozorContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new GreenDozorContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.GreenDozor;
        }
    }
}
