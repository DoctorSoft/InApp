﻿using System;
using System.Linq;
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
                /*AccountName.Kioto,
                AccountName.MyGrodno,
                AccountName.Sport,
                AccountName.Ozerny,*/
                AccountName.GreenDozor,
                AccountName.SystemDoctor, 
                AccountName.GreenShop,
                AccountName.GadalkaTamara, 
                AccountName.Firuza,
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

            while (true)
            {
                try
                {
                    var dbData = bases[index];
                    var db = (DataBaseContext)Activator.CreateInstance(dbData.DataBaseType);

                    Console.WriteLine("=======Start=====");

                    service.RunBackgroundSearchingUslessUsers(db, spyDriver, spyContext, i => Console.WriteLine("===" + db.GetAccountName().ToString("G") + "====" + i + "===="));
                }
                catch (Exception)
                {
                    // ignored
                }
                finally
                {
                    index = (index + 1) % count;
                }
            }
        }
    }
}
