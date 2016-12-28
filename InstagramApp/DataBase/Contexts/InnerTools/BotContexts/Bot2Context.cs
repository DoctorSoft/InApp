using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.BotContexts
{
    [AccountBase(AccountName = AccountName._Bot_2)]
    public class Bot2Context: BotContext
    {
        public Bot2Context() : base(AccountName._Bot_2)
        {
        }
    }
}
