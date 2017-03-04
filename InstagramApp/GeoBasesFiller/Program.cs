using System;
using System.Collections.Generic;
using System.Threading;
using Constants;
using DataBase.Contexts.InnerTools;
using DataBase.Contexts.InnerTools.StoreContexts;
using InstagramApp;
using OpenQA.Selenium.Chrome;

namespace GeoBasesFiller
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dictionary = new Dictionary<IStoreContext, List<GeoName>>
            {
                {new GrodnoGeoStoreContext(), new List<GeoName> { GeoName.Grodno, GeoName.Grodno_Center, GeoName.Grodno_Deviatovka }},
                {new MinskGeoStoreContext(), new List<GeoName> { GeoName.Minsk }}
            };

            var driver = new ChromeDriver();

            var service = new InstagramService();

            while (true)
            {
                foreach (var context in dictionary.Keys)
                {
                    foreach (var geo in dictionary[context])
                    {
                        service.SaveUsersByGeo(driver, context, geo);
                    }
                }

                Thread.Sleep((int)TimeSpan.FromMinutes(1).TotalMilliseconds);
            }
        }
    }
}
