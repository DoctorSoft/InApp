using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.BotContexts
{
    [AccountBase(AccountName = AccountName._Bot_8)]
    public class Bot8Context: BotContext
    {
        public Bot8Context() : base(AccountName._Bot_8)
        {
        }
    }
}
