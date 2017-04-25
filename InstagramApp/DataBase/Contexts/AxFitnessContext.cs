using Constants;
using Constants.Attributes;
using DataBase.Contexts.InnerTools;

namespace DataBase.Contexts
{
    [AccountBase(AccountName = AccountName.AxFitness)]
    public class AxFitnessContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new AxFitnessContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.AxFitness;
        }
    }
}
