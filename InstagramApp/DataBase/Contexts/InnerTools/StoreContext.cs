using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using Constants;
using DataBase.Configurations;
using DataBase.Models;
using EntityFramework.BulkInsert.Extensions;

namespace DataBase.Contexts.InnerTools
{
    public abstract class StoreContext: DbContext, IStoreContext
    {
        public StoreContext()
            :base("DefaultConnection")
        {
        }

        protected StoreContext(string connectionName)
            : base(connectionName)
        {
            
        }

        public abstract AccountName GetAccountName();

        public DbSet<UserDbModel> Users { get; set; }

        public void BulkInsert<T>(IEnumerable<T> entities, int? batchSize = null)
        {
            BulkInsertExtension.BulkInsert(this, entities, batchSize);
        }

        public void BulkInsert<T>(IEnumerable<T> entities, BulkInsertOptions options)
        {
            BulkInsertExtension.BulkInsert(this, entities, options);
        }

        public void BulkInsert<T>(IEnumerable<T> entities, SqlBulkCopyOptions sqlBulkCopyOptions, int? batchSize = null)
        {
            BulkInsertExtension.BulkInsert(this, entities, sqlBulkCopyOptions, batchSize);
        }

        public void BulkInsert<T>(IEnumerable<T> entities, IDbTransaction transaction,
            SqlBulkCopyOptions sqlBulkCopyOptions = SqlBulkCopyOptions.Default, int? batchSize = null)
        {
            BulkInsertExtension.BulkInsert(this, entities, transaction, sqlBulkCopyOptions, batchSize);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration(GetAccountName()));

            base.OnModelCreating(modelBuilder);
        }
    }
}
