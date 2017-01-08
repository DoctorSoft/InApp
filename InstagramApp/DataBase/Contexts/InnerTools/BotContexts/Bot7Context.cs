using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;
using Constants.Attributes;

namespace DataBase.Contexts.InnerTools.BotContexts
{
    [AccountBase(AccountName = AccountName._Bot_7)]
    public class Bot7Context: BotContext
    {
        public Bot7Context() : base(AccountName._Bot_7)
        {
        }
    }
}
