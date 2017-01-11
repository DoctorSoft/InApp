using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;

namespace Tools.Factories
{
    public interface IContextFactory
    {
        DataBaseContext GetContext(AccountName accountId);

        ISettingsContext GetBotContext(AccountName accountId);
    }
}