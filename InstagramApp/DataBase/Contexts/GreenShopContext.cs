using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.GreenShop)]
    public class GreenShopContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new GreenShopContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.GreenShop;
        }
    }
}
