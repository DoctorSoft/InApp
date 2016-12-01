using Constants;

namespace DataBase.Contexts
{
    public class EtalonContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new EtalonContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Etalon;
        }
    }
}
