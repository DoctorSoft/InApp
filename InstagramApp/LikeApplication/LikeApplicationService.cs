using System;
using System.Collections.Generic;
using System.Linq;
using Constants;
using DataBase.Contexts.InnerTools;
using Tools.Factories;

namespace LikeApplication
{
    public class LikeApplicationService
    {
        private static readonly Random random = new Random();

        public List<ISettingsContext> GetRandomBots()
        {
            var bots = Enum.GetValues(typeof(AccountName))
                .Cast<AccountName>()
                .Where(name => (int)name > 1000)
                .Where(name => name != AccountName._Bot_9) // block dead account
                .OrderBy(name => Guid.NewGuid())
                //.Where(name => random.Next(2) == 0)
                .ToList();
                //new List<AccountName> { AccountName._Bot_9 };

            return bots.Select(name => new ContextFactory().GetBotContext(name)).ToList();
        }

        public List<string> GetMidiasToLike()
        {
            return new List<string>
            {
                "https://www.instagram.com/p/BOKn3liAycs/",
                "https://www.instagram.com/p/BNmiUxWAtDx/",
                "https://www.instagram.com/p/BNUdgIsAye0/",
            };
        } 
    }
}
