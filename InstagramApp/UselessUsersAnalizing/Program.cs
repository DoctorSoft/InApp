using System;
using System.Linq;
using System.Threading;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using InstagramApp;
using Tools.DatabaseSearcher;

namespace UselessUsersAnalizing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var accounts = new[]
            {
                AccountName.GrodnoOfficial,
                AccountName.Kioto,
                AccountName.MyGrodno,
                AccountName.Ozerny,
                AccountName.Sport, 
                AccountName.SystemDoctor, 
                AccountName.Gadanie, 
                AccountName.Nazar, 
                AccountName.Firuza,
                AccountName.GreenDozor,  
                AccountName.Karina, 
                AccountName.Mayontak, 
                AccountName.Augustovski,
                AccountName.MKGrodno
            };
            
            var bases = DataBaseSearcher.GetTypesWithAttribute(
                AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.FullName.Contains("DataBase")),
                name => accounts.Contains(name))
                .ToList();

            var count = bases.Count;
            var index = 1;

            var service = new InstagramService();

            var spyContext = new SportContext(); // Spy !!!
            var spyDriver = service.RegisterNewDriver(spyContext);

            while (true)
            {
                try
                {
                    var dbData = bases[index];
                    var db = (DataBaseContext)Activator.CreateInstance(dbData.DataBaseType);

                    Console.WriteLine("=======Start=====" + dbData.AccountName.ToString("G"));

                    try
                    {
                        service.AddActivityHistoryMarkBySpy(spyDriver, spyContext, db);
                        Console.WriteLine("Account got activity mark");

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Account failed to get activity mark");
                    }
                    service.RunBackgroundSearchingUslessUsers(db, spyDriver, spyContext, i => Console.WriteLine("===" + db.GetAccountName().ToString("G") + "====" + i + "===="));
                }
                catch (Exception)
                {
                    // ignored
                }
                finally
                {
                    index = (index + 1) % count;
                    Thread.Sleep(TimeSpan.FromMinutes(5));
                }
            }
        }
    }
}
