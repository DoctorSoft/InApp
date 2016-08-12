using System.Data.Entity;
using Constants;
using DataBase.Configurations;
using DataBase.Models;

namespace DataBase.Contexts
{
    public abstract class DataBaseContext : DbContext
    {
        public DataBaseContext()
            :base("DefaultConnection")
        {
            
        }

        public DbSet<LanguageDbModel> Languages { get; set; }

        public DbSet<MediaDbModel> Medias { get; set; }

        public DbSet<RegionDbModel> Regions { get; set; }

        public DbSet<UserDbModel> Users { get; set; }

        protected abstract AccountName GetAccountName(); 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LanguageConfiguration(GetAccountName()));
            modelBuilder.Configurations.Add(new MediaConfiguration(GetAccountName()));
            modelBuilder.Configurations.Add(new RegionConfiguration(GetAccountName()));
            modelBuilder.Configurations.Add(new UserConfiguration(GetAccountName()));

            base.OnModelCreating(modelBuilder);
        }
    }
}
