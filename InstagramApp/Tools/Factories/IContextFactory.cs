using Constants;
using DataBase.Contexts;

namespace Tools.Factories
{
    public interface IContextFactory
    {
        DataBaseContext GetContext(AccountName accountId);
    }
}