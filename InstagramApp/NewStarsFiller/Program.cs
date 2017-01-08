using System;
using System.Collections.Generic;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using InstagramApp;
using Tools.DatabaseSearcher;

namespace NewStarsFiller
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var accounts = new[]
            {
                AccountName.SalsaRika, 
            };

            var sources = new List<string>
            {
                "https://www.instagram.com/canon.by/"
            };

            var bases = DataBaseSearcher.GetTypesWithAttribute(
                AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.FullName.Contains("DataBase")),
                name => accounts.Contains(name))
                .ToList();

            var count = bases.Count;
            var index = 0;

            var service = new InstagramService();

            var spyContext = new NazarContext(); // Spy !!!
            var spyDriver = service.RegisterNewDriver(spyContext);

            while (index != count)
            {
                try
                {
                    var dbData = bases[index];
                    var db = (DataBaseContext)Activator.CreateInstance(dbData.DataBaseType);

                    Console.WriteLine("=======Start=====");

                    service.RunBackgroundSearchingNewStars(db, spyDriver, spyContext, sources, i => Console.WriteLine("===" + db.GetAccountName().ToString("G") + "====" + i + "===="));
                }
                catch (Exception)
                {
                    // ignored
                }
                finally
                {
                    index++;
                }
            }

            spyDriver.Close();
        }
    }
}
