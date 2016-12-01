using Constants;

namespace DataBase.Contexts
{
    public class AnastasiyaContext : DataBaseContext
    {
        public override DataBaseContext OpenCopyContext()
        {
            return new AnastasiyaContext();
        }

        public override AccountName GetAccountName()
        {
            return AccountName.Anastasiya;
        }
    }
}
