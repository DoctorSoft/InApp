using Constants;

namespace DataBase.Contexts
{
    public class NikonContext : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.Nikon;
        }
    }
}
