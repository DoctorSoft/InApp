using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.StoreContexts
{
    [AccountBase(AccountName = AccountName.__Stroe_Magic_Base_2018)]
    public class MagicBaseContext : StoreContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.__Stroe_Magic_Base_2018;
        }
    }
}
