using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.StoreContexts
{
    [AccountBase(AccountName = AccountName.__Store_Travel_Feb_2018)]
    public class Travel2018StoreContext : StoreContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.__Store_Travel_Feb_2018;
        }
    }
}
