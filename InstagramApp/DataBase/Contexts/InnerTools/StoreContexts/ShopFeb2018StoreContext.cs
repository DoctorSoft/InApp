using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.StoreContexts
{
    [AccountBase(AccountName = AccountName.__Shop_Feb_2018)]
    public class ShopFeb2018StoreContext : StoreContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.__Shop_Feb_2018;
        }
    }
}
