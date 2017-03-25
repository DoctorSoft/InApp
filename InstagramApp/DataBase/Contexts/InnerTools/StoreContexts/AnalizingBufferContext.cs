using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.StoreContexts
{
    [AccountBase(AccountName = AccountName.__AnializingBuffer)]
    public class AnalizingBufferContext : StoreContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.__AnializingBuffer;
        }
    }
}
