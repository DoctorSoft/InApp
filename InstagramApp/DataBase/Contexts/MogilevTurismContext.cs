using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.MogilevTurism)]
    public class MogilevTurismContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new MogilevTurismContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.MogilevTurism;
        }
    }
}
