using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.BotContexts
{
    [AccountBase(AccountName = AccountName._Bot_3)]
    public class Bot3Context: BotContext
    {
        public Bot3Context() : base(AccountName._Bot_3)
        {
        }
    }
}
