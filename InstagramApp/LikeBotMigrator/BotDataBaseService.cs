using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;

namespace LikeBotMigrator
{
    public static class BotDataBaseService
    {
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
