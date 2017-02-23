using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.StoreContexts
{
    [AccountBase(AccountName = AccountName.__FilterResult)]
    public class FilterResultStoreContext : StoreContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.__FilterResult;
        }
    }
}
