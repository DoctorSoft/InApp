using Constants;
using DataBase.Contexts;

namespace DataBase.Factories
{
    public interface IContextFactory
    {
        DataBaseContext GetContext(AccountName accountId);
    }
}