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
                if (!TableExists(GetTableName(accountName), connectionString))
                {
                    Create(GetTableName(accountName), connectionString);
                }
            }
        }

        public static string GetTableName(AccountName accountName)
        {
            return "__" + accountName.ToString("G") + "_ProfilesSettings";
        }

        public static bool TableExists(string tableName, string conString)
        {
            using (var connection = new SqlConnection(conString))
            {
                try
                {
                    var sql = string.Format(
                            "SELECT COUNT(*) FROM information_schema.tables WHERE table_name = '{0}'",
                            tableName);
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Connection.Open();
                        var count = Convert.ToInt32(command.ExecuteScalar());
                        command.Connection.Close();

                        return count > 0;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static void Create(string name, string conString)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("CREATE TABLE [dbo].[" + name + "]("
                                + "[ID] [bigint] IDENTITY(1,1) NOT NULL,"
                                + "[InstagramtId] [bigint] NOT NULL,"
                                + "[Login] [nvarchar](max) NULL,"
                                + "[Password] [nvarchar](max) NULL,"
                                + "[HomePageUrl] [nvarchar](max) NULL,"
                                + "[PreviousFollowingsSynchDate] [datetime] NULL,"
                                + "[Proxy] [nvarchar](max) NULL,"
                                + "[ProxyLogin] [nvarchar](max) NULL,"
                                + "[ProxyPassword] [nvarchar](max) NULL,"
                                + "[RemoveAllUsers] [bit] NOT NULL,"
                                + "[Cookies] [nvarchar](max) NULL);", new SqlConnection(conString)))
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
