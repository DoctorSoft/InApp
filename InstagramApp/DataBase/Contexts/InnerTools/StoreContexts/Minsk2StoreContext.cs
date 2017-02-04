using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.StoreContexts
{
    [AccountBase(AccountName = AccountName.__Store_Minsk2)]
    public class Minsk2StoreContext : StoreContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.__Store_Minsk2;
        }
    }
}
