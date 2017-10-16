using System;
using System.Data.SqlClient;
using System.Linq;
using Constants;

namespace LikeBotMigrator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var connectionString = "Data Source=v04.bizneshost.by,32433;Initial Catalog=systemdo_systemdoc;Persist Security Info=True;User ID=systemdo_systemdoc;Password=aX3lxzsikvyjngpmtoeb";

            var bots = Enum.GetValues(typeof(AccountName)).Cast<AccountName>().Where(name => (int)name > 1000).ToList();

            foreach (var accountName in bots)
            {
                if (!BotDataBaseService.TableExists(BotDataBaseService.GetTableName(accountName), connectionString))
                {
                    BotDataBaseService.Create(BotDataBaseService.GetTableName(accountName), connectionString);
                }
            }
        }
    }
}
