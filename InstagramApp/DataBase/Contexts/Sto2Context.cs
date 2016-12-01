using Constants;

namespace DataBase.Contexts
{
    public class Sto2Context : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new Sto2Context();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Sto2;
        }
    }
}
