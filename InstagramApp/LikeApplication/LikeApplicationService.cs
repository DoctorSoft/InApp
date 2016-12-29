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
        
        public List<SettingsContext> GetRadnomBots()
        {
            var bots = Enum.GetValues(typeof(AccountName))
                .Cast<AccountName>()
                .Where(name => (int)name > 1000)
                .Where(name => random.Next(2) == 0)
                .ToList();

            return bots.Select(name => new ContextFactory().GetBotContext(name)).ToList();
        }

        public List<string> GetMidiasToLike()
        {
            return new List<string>
            {
                "https://www.instagram.com/p/BOiVmmHjfMj/"
            };
        } 
    }
}
