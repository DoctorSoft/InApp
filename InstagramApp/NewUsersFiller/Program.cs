using System;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using InstagramApp;
using Tools.DatabaseSearcher;

namespace NewUsersFiller
{
    public class Program
    {
        static void Main(string[] args)
        {
            var accounts = new[]
            {
                AccountName.__Store_Gomel2
            };

            var links = new[]
            {
                "https://www.instagram.com/yana_medvezhenko/",
                "https://www.instagram.com/mylushko/",
                "https://www.instagram.com/sayana_gomel/",
                "https://www.instagram.com/dasha_959_/",
                "https://www.instagram.com/komissionka.lux.shop/",
                "https://www.instagram.com/dress_of_dream_gomel/",
                "https://www.instagram.com/nemo_gomel/",
                "https://www.instagram.com/thematic_foto_gomel/"
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
                    var db = (IStoreContext)Activator.CreateInstance(dbData.DataBaseType);

                    Console.WriteLine("=======Start=====");

                    //service. 

                    foreach (var link in links)
                    {
                        service.AddBase(db, link);
                    }

                    service.RunBackgroundSearchingNewUsers(db, spyDriver, spyContext, i => Console.WriteLine("===" + db.GetAccountName().ToString("G") + "====" + i + "===="), true, true);
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
