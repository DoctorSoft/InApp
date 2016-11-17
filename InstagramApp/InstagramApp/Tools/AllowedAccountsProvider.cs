using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Constants;

namespace InstagramApp.Tools
{
    public class AllowedAccountsProvider
    {
        public IEnumerable<AccountName> GetAllowedAccounts()
        {
            var names = Enum.GetValues(typeof (AccountName)).Cast<AccountName>().ToList();
            using (var reader = new StreamReader("accounts.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var nextLine = reader.ReadLine();

                    if (string.IsNullOrWhiteSpace(nextLine))
                    {
                        continue;
                    }

                    if (nextLine.First() != '+')
                    {
                        continue;
                    }

                    var typeName = nextLine.Replace("+", "");

                    foreach (var name in names.Where(name => name.ToString("G") == typeName))
                    {
                        yield return name;
                        break;
                    }
                }
            }
        }
    }
}
