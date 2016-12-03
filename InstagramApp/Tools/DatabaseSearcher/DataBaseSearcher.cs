using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Constants;
using Constants.Attributes;

namespace Tools.DatabaseSearcher
{
    public static class DataBaseSearcher
    {
        public static IEnumerable<DataBaseAccountModel> GetTypesWithAttribute(IEnumerable<Assembly> assemblies)
        {
            return GetTypesWithAttribute(assemblies, name => true);
        }

        public static IEnumerable<DataBaseAccountModel> GetTypesWithAttribute(IEnumerable<Assembly> assemblies, Func<AccountName, bool> expression)
        {
            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    var attribute = type.GetCustomAttributes(typeof (AccountBaseAttribute), true).FirstOrDefault();
                    var realAttribute = attribute as AccountBaseAttribute;
                    
                    if (realAttribute == null)
                    {
                        continue;
                    }

                    if (!expression(realAttribute.AccountName))
                    {
                        continue;
                    }

                    yield return new DataBaseAccountModel
                    {
                        AccountName = realAttribute.AccountName,
                        DataBaseType = type
                    };
                }
            }
        }
    }
}
