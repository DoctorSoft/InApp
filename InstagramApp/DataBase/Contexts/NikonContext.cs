using Constants;

namespace DataBase.Contexts
{
    public class NikonContext : DataBaseContext
    {
        protected override AccountName GetAccountName()
        {
            return AccountName.Nikon;
        }
    }
}
