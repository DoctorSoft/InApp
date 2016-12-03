using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataBase.Contexts;
using Tools.DatabaseSearcher;

namespace UselessUsersAnalizing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var spy = new NazarContext();
            var bases = DataBaseSearcher.GetTypesWithAttribute(AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(assembly => assembly.FullName.Contains("DataBase"))).ToList();

            var dataBaseData = bases.FirstOrDefault();

            var db = Activator.CreateInstance(dataBaseData.DataBaseType);
        }
    }
}
