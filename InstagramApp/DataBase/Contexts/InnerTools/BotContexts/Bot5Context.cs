using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.BotContexts
{
    [AccountBase(AccountName = AccountName._Bot_5)]
    public class Bot5Context : BotContext
    {
        public Bot5Context() : base(AccountName._Bot_5)
        {
        }
    }
}
