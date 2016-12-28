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
            var connectionString = "Data Source=v02.bizneshost.by,32433;Initial Catalog=SystemDoctor;Persist Security Info=True;User ID=systemdo;Password=3Yk6lj4aM4";

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
