using System.Data.Entity;
using Constants;
using DataBase.Configurations;
using DataBase.Models;

namespace DataBase.Contexts
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
            :base("DefaultConnection")
        {
            
        }

        public DbSet<LanguageDbModel> Languages { get; set; }

        public DbSet<MediaDbModel> Medias { get; set; }

        public DbSet<RegionDbModel> Regions { get; set; }

        public DbSet<UserDbModel> Users { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LanguageConfiguration());
            modelBuilder.Configurations.Add(new MediaConfiguration());
            modelBuilder.Configurations.Add(new RegionConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
