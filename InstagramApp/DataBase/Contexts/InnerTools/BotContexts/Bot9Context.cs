using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.BotContexts
{
    [AccountBase(AccountName = AccountName._Bot_9)]
    public class Bot9Context: BotContext
    {
        public Bot9Context() : base(AccountName._Bot_9)
        {
        }
    }
}
