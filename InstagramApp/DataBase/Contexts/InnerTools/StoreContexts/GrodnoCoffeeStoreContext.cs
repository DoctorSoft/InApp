using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.StoreContexts
{
    [AccountBase(AccountName = AccountName.__Store_Grodno_Coffee)]
    public class GrodnoCoffeeeStoreContext : StoreContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.__Store_Grodno_Coffee;
        }
    }
}
