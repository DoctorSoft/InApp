using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.StoreContexts
{
    [AccountBase(AccountName = AccountName.__Store_Gomel2)]
    public class Gomel2StoreContext : StoreContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.__Store_Gomel2;
        }
    }
}
