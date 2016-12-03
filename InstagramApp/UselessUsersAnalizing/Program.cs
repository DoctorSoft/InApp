﻿using System;
using System.Linq;
using Constants;
using DataBase.Contexts;
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
                AccountName.MyGrodno,
                AccountName.Anastasiya,
                AccountName.Gadanie,
                AccountName.GrodnoOfficial,
                AccountName.Karina,
                AccountName.Kioto,
                AccountName.Augustovski,
                AccountName.MyGrodno,
                AccountName.Sport,
                AccountName.Sto,
                AccountName.Sto2,
                AccountName.Ozerny
            };
            
            var bases = DataBaseSearcher.GetTypesWithAttribute(
                AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.FullName.Contains("DataBase")),
                name => accounts.Contains(name))
                .ToList();

            var count = bases.Count;
            var index = 1;

            var service = new InstagramService();

            var spyContext = new NazarContext(); // Spy !!!
            var spyDriver = service.RegisterNewDriver(spyContext);

            while (true)
            {
                try
                {
                    var dbData = bases[index];
                    var db = (DataBaseContext) Activator.CreateInstance(dbData.DataBaseType);
                    service.RunBackgroundSearchingUslessUsers(db, spyDriver, spyContext);
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
