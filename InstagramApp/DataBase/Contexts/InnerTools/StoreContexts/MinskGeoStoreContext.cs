using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.StoreContexts
{
    [AccountBase(AccountName = AccountName.__MinskGeo)]
    public class MinskGeoStoreContext : StoreContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.__MinskGeo;
        }
    }
}
