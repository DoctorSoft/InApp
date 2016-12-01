using Constants;

namespace DataBase.Contexts
{
    public class NikonContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new NikonContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Nikon;
        }
    }
}
