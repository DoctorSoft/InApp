using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.StoreContexts
{
    [AccountBase(AccountName = AccountName.__Store_Minsk_Insta)]
    public class MinskInstaContext : StoreContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.__Store_Minsk_Insta;
        }
    }
}
