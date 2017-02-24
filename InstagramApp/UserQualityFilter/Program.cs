using System;
using System.Collections.Generic;
using DataBase.Contexts.InnerTools.StoreContexts;
using InstagramApp;
using OpenQA.Selenium.Chrome;

namespace UserQualityFilter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var service = new InstagramService();

            var sourceBase = new Grodno2StoreContext();
            var destinationBase = new FilterResultStoreContext();

            var driver = new ChromeDriver();

            var languages = new List<string>
            {
                "русский",
                "английский",
                "белорусский"
            };

            var words = new List<string>()
            {
                "гродно",
                "grodno",
                "гродна",
                "гродн",
                "grodn",
                "Grodn",
                "Гродн",
                "Belar",
                "Белар",
                "Белор",
            };

            var limit = 10000;

            Action<int, int, string, bool> makeRecors = (index, count, link, passed) =>
            {
                Console.WriteLine("{0}/{1} ({3}) - {2}", index, count, link, passed ? "Passed" : "Failed");
            };

            service.FilterUsers(driver, sourceBase, destinationBase, languages, limit, words, makeRecors);
        }
    }
}
