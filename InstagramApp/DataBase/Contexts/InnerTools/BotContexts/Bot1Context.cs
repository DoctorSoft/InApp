using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.BotContexts
{
    [AccountBase(AccountName = AccountName._Bot_1)]
    public class Bot1Context : BotContext
    {
        public Bot1Context() : base(AccountName._Bot_1)
        {
        }
    }
}
