using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.SystemDoctor)]
    public class SystemDoctorContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new SystemDoctorContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.SystemDoctor;
        }
    }
}
