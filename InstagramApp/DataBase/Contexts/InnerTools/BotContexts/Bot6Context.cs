using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.BotContexts
{
    [AccountBase(AccountName = AccountName._Bot_6)]
    public class Bot6Context: BotContext
    {
        public Bot6Context() : base(AccountName._Bot_6)
        {
        }
    }
}
