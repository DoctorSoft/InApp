using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.StoreContexts
{
    [AccountBase(AccountName = AccountName.__Reester)]
    public class ReesterStoreContext : StoreContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.__Reester;
        }
    }
}
