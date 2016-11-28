using Constants;

namespace DataBase.Contexts
{
    public class Sto2Context : DataBaseContext
    {
        public override AccountName GetAccountName()
        {
            return AccountName.Sto2;
        }
    }
}
