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
                AccountName.__Store_Belarus
            };

            const bool following = false; //подписки
            const bool followers = true; //Подпищики

            var links = new[]
            {
                "https://www.instagram.com/yura.yaroshik",
                "https://www.instagram.com/levongziryan",
                "https://www.instagram.com/dmitry_miachikoff",
                "https://www.instagram.com/vkotovby",
                "https://www.instagram.com/luckinday",
                "https://www.instagram.com/da_demidov",
                "https://www.instagram.com/stanislove_melnikov",
                "https://www.instagram.com/belyavskyanton",
                "https://www.instagram.com/sergei_khozyashev",
                "https://www.instagram.com/romanborodavkin",
                "https://www.instagram.com/arthur_belousov",
                "https://www.instagram.com/aleksandr_neson",
                "https://www.instagram.com/lukanesko",
                "https://www.instagram.com/vedushchiy_yevgeniy_gold"
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
