using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Constants;

namespace InstagramApp.Tools
{
    public class Settings
    {
        public int Cicles { get; set; }
        public int Follows { get; set; }
        public int UnFollows { get; set; }
        public int Likes { get; set; }
    }

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

        public Settings GetSettings()
        {
            var settings = new Settings();
            using (var reader = new StreamReader("settings.txt"))
            {
                settings.Cicles = int.Parse(reader.ReadLine().Split(' ').First());
                settings.Follows = int.Parse(reader.ReadLine().Split(' ').First());
                settings.UnFollows = int.Parse(reader.ReadLine().Split(' ').First());
                settings.Likes = int.Parse(reader.ReadLine().Split(' ').First());
            }

            return settings;
        }

    }
}
