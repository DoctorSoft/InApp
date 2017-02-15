using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.StoreContexts
{
    [AccountBase(AccountName = AccountName.__BelarusCommercial)]
    public class BelarusCommercialContext : StoreContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.__BelarusCommercial;
        }
    }
}
