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
                AccountName.__Store_Mogilev_Minsk
            };

            const bool following = true; //подписки
            const bool followers = true; //Подпищики

            var links = new[]
            {
                "https://www.instagram.com/mogilev.life.style/"
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
