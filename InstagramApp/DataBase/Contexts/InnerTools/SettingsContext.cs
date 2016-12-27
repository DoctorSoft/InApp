using System.Data.Entity;
using Constants;
using DataBase.Configurations;
using DataBase.Models;

namespace DataBase.Contexts.InnerTools
{
    public abstract class SettingsContext : DbContext
    {
        public SettingsContext()
            :base("DefaultConnection")
        {
            
        }

        protected SettingsContext(string connectionName)
            : base(connectionName)
        {
            
        }
        public abstract AccountName GetAccountName();

        public DbSet<ProfileSettingsDbModel> ProfileSettings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProfilesSettingsConfiguration(GetAccountName()));

            base.OnModelCreating(modelBuilder);
        }
    }
}
