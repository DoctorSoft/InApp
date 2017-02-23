using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.StoreContexts
{
    [AccountBase(AccountName = AccountName.__Store_Vladivostok2)]
    public class Vladivostok2StoreContext : StoreContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.__Store_Vladivostok2;
        }
    }
}
