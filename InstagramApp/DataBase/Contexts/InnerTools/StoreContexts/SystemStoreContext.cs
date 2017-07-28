using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.StoreContexts
{
    [AccountBase(AccountName = AccountName.__Store_System)]
    public class SystemStoreContext : StoreContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.__Store_System;
        }
    }
}
