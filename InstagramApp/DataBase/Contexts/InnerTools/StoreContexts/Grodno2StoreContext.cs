using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.StoreContexts
{
    [AccountBase(AccountName = AccountName.__Store_Grodno2)]
    public class Grodno2StoreContext : StoreContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.__Store_Grodno2;
        }
    }
}
