using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.BotContexts
{
    [AccountBase(AccountName = AccountName._Bot_10)]
    public class Bot10Context: BotContext
    {
        public Bot10Context() : base(AccountName._Bot_10)
        {
        }
    }
}
