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
            // cool bases: "https://www.instagram.com/homelike_nails/" for Gomel

            // taravel bases: "https://www.instagram.com/itakapl/" for Poland
            // "https://www.instagram.com/airbaltic/" for baltic



            //https://www.instagram.com/_natas.h.a_/ following
            //https://www.instagram.com/anastasiaprokopovich/
            //https://www.instagram.com/vadikes/ followers

            //https://www.instagram.com/alexmikulik/ followers
            //https://www.instagram.com/katrina_emelianenko/
            //https://www.instagram.com/bestvscobelarus/
            //https://www.instagram.com/gribalevalarisa/
            //https://www.instagram.com/grodnonow/

            var accounts = new[]
            {
                AccountName.Karina,
            };

            const bool following = true; //подписки
            const bool followers = true; //Подпищики

            var links = new[]
            {
                "https://www.instagram.com/gomel_region/"
            };

            var bases = DataBaseSearcher.GetTypesWithAttribute(
                AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.FullName.Contains("DataBase")),
                name => accounts.Contains(name))
                .ToList();

            var count = bases.Count;
            var index = 0;

            var service = new InstagramService();

            var spyContext = new SportContext(); // Spy !!!
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

                    service.RunBackgroundSearchingNewUsers(db, spyDriver, spyContext, i => Console.WriteLine("===" + db.GetAccountName().ToString("G") + "====" + i + "===="), following, followers);
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
