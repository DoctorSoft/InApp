using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using Constants;
using DataBase.Models;
using EntityFramework.BulkInsert.Extensions;

namespace DataBase.Contexts.InnerTools
{
    public interface IStoreContext
    {
        AccountName GetAccountName();

        DbSet<UserDbModel> Users { get; set; }

        int SaveChanges();

        void BulkInsert<T>(IEnumerable<T> entities, int? batchSize = null);

        void BulkInsert<T>(IEnumerable<T> entities, BulkInsertOptions options);

        void BulkInsert<T>(IEnumerable<T> entities, SqlBulkCopyOptions sqlBulkCopyOptions, int? batchSize = null);

        void BulkInsert<T>(IEnumerable<T> entities, IDbTransaction transaction, SqlBulkCopyOptions sqlBulkCopyOptions = SqlBulkCopyOptions.Default, int? batchSize = null);

    }
}
