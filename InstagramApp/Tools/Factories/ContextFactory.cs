using System;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using Tools.DatabaseSearcher;

namespace Tools.Factories
{
    public class ContextFactory : IContextFactory
    {
        public DataBaseContext GetContext(AccountName accountId)
        {
            var bases = DataBaseSearcher.GetTypesWithAttribute(
                AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.FullName.Contains("DataBase")),
                name => name == accountId)
                .ToList();

            var dbData = bases.FirstOrDefault();
            var db = (DataBaseContext) Activator.CreateInstance(dbData.DataBaseType);

            return db;
        }
    }
}