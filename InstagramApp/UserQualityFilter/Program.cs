using System.Collections.Generic;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools.StoreContexts;
using InstagramApp;

namespace UserQualityFilter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var service = new InstagramService();

            var sourceBase = new Grodno2StoreContext();
            var destinationBase = new FilterResultStoreContext();

            var languages = new List<string>
            {
                "русский",
                "английский",
                "белорусский"
            };

            service.FilterUsers(sourceBase, destinationBase, languages);
        }
    }
}
