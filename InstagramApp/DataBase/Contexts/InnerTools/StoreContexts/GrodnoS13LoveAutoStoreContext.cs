using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.StoreContexts
{
    [AccountBase(AccountName = AccountName.__Store_Grodno_S13_Love_Auto)]
    public class GrodnoS13LoveAutoStoreContext : StoreContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.__Store_Grodno_S13_Love_Auto;
        }
    }
}
