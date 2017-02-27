using System;
using System.Collections.Generic;
using DataBase.Contexts.InnerTools.StoreContexts;
using InstagramApp;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace UserQualityFilter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var service = new InstagramService();

            var sourceBase = new MinskStoreContext();
            var destinationBase = new FilterResultStoreContext();

            RemoteWebDriver driver = null;

            var languages = new List<string>
            {
                "русский",
                //"английский",
                //"белорусский"
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
                "minsk",
                "brest", 
                "минск",
                "брест",
                "vitebsk",
                "витебск",
                "mogil",
                "могил",
                "lida",
                "лида",
                "витеб",
                "viteb",
                "gomel",
                "гомел",
                "homel",
                "бобруй"
            };

            var limit = 5000;
            var emptyAllowed = false;

            Action<int, int, string, bool, string> makeRecors = (index, count, link, passed, cause) =>
            {
                Console.WriteLine("{0}/{1} ({3}) - {2} \n {4} \n\n", index, count, link, passed ? "Passed" : "Failed", cause);
            };

            service.FilterUsers(driver, sourceBase, destinationBase, languages, limit, emptyAllowed, words, makeRecors);
        }
    }
}
