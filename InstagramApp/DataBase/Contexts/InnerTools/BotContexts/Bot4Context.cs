using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.BotContexts
{
    [AccountBase(AccountName = AccountName._Bot_4)]
    public class Bot4Context: BotContext
    {
        public Bot4Context() : base(AccountName._Bot_4)
        {
        }
    }
}
