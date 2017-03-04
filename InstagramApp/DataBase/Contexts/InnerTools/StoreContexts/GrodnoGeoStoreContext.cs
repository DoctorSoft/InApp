using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.StoreContexts
{
    [AccountBase(AccountName = AccountName.__GrodnoGeo)]
    public class GrodnoGeoStoreContext : StoreContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.__GrodnoGeo;
        }
    }
}
