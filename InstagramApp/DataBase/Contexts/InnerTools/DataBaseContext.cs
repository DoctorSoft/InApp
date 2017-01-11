using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using Constants;
using DataBase.Configurations;
using DataBase.Configurations.Content;
using DataBase.Models;
using DataBase.Models.Content;
using EntityFramework.BulkInsert.Extensions;

namespace DataBase.Contexts.InnerTools
{
    public abstract class DataBaseContext : DbContext, ISettingsContext, IStoreContext
    {
        public DataBaseContext()
            :base("DefaultConnection")
        {
            
        }

        protected DataBaseContext(string connectionName)
            : base(connectionName)
        {
            
        }

        public abstract DataBaseContext OpenCopyContext();

        public DbSet<ActivityHistoryDbModel> ActivityHistories { get; set; }

        public DbSet<LanguageDbModel> Languages { get; set; }

        public DbSet<MediaDbModel> Medias { get; set; }

        public DbSet<RegionDbModel> Regions { get; set; }

        public DbSet<UserDbModel> Users { get; set; }

        public DbSet<SpamWordDbModel> SpamWords { get; set; }

        public DbSet<HashTagDbModel> HashTags { get; set; }

        public DbSet<FeaturesDbModel> Features { get; set; }

        public DbSet<FunctionalityDbModel> Functionalities { get; set; }

        public DbSet<ColourDbModel> Colours { get; set; }

        public DbSet<ContentColourDbModel> ContentColours { get; set; }

        public DbSet<ContentDbModel> Contents { get; set; }

        public DbSet<ContentLikesHistoryDbModel> ContentLikesHistories { get; set; }

        public DbSet<ContentTypeDbModel> ContentTypes { get; set; }

        public DbSet<FunctionalityRecordDbModel> FunctionalityRecords { get; set; }

        public DbSet<FunctionalityReportDbModel> FunctionalityReports { get; set; }

        public DbSet<StarRecordDbModel> StarRecords { get; set; }

        public DbSet<ProfileSettingsDbModel> ProfileSettings { get; set; }

        public abstract AccountName GetAccountName();

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
            modelBuilder.Configurations.Add(new ActivityHistoryConfiguration(GetAccountName()));
            modelBuilder.Configurations.Add(new LanguageConfiguration(GetAccountName()));
            modelBuilder.Configurations.Add(new MediaConfiguration(GetAccountName()));
            modelBuilder.Configurations.Add(new RegionConfiguration(GetAccountName()));
            modelBuilder.Configurations.Add(new UserConfiguration(GetAccountName()));
            modelBuilder.Configurations.Add(new ProfilesSettingsConfiguration(GetAccountName()));
            modelBuilder.Configurations.Add(new SpamWordConfiguration(GetAccountName()));
            modelBuilder.Configurations.Add(new HashTagConfiguration(GetAccountName()));
            modelBuilder.Configurations.Add(new FeaturesConfiguration(GetAccountName()));
            modelBuilder.Configurations.Add(new FunctionalityConfiguration(GetAccountName()));
            modelBuilder.Configurations.Add(new FunctionalityRecordConfiguration(GetAccountName()));
            modelBuilder.Configurations.Add(new FunctionalityReportConfiguration(GetAccountName()));
            modelBuilder.Configurations.Add(new StarRecordConfiguration(GetAccountName()));

            modelBuilder.Configurations.Add(new ContentTypeConfiguration(GetAccountName()));
            modelBuilder.Configurations.Add(new ContentConfiguration(GetAccountName()));
            modelBuilder.Configurations.Add(new ColourConfiguration(GetAccountName()));
            modelBuilder.Configurations.Add(new ContentColourConfiguration(GetAccountName()));
            modelBuilder.Configurations.Add(new ContentLikesHistoryConfiguration(GetAccountName()));

            base.OnModelCreating(modelBuilder);
        }
    }
}
