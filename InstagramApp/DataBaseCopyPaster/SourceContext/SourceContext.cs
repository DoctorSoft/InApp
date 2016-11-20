using Constants;
using DataBase.Contexts;

namespace DataBaseCopyPaster.SourceContext
{
    public class SourceContext : DataBaseContext
    {
        private readonly AccountName accountName;

        public SourceContext(AccountName accountName)
            : base("SourceConnection")
        {
            this.accountName = accountName;
        }

        public override AccountName GetAccountName()
        {
            return accountName;
        }
    }
}
