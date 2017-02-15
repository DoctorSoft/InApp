using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.StoreContexts
{
    [AccountBase(AccountName = AccountName.__Vrangel)]
    public class VrangelContext : StoreContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.__Vrangel;
        }
    }
}
