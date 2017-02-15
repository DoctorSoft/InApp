using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.StoreContexts
{
    [AccountBase(AccountName = AccountName.__Store_GrodnoNews)]
    public class GrodnoNewsStoreContext : StoreContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.__Store_GrodnoNews;
        }
    }
}
