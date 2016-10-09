using System.Data.Entity;
using DataBase.Configurations.LikeApplication;
using DataBase.Models.LikeApplication;

namespace DataBase.Contexts.LikeApplication
{
    public class LikeApplicationContext : DbContext
    {
        public LikeApplicationContext()
            :base("DefaultConnection")
        {
            
        }

        public DbSet<ProxyDbModel> Proxies { get; set; }

        public DbSet<LikeMediaDbModel> Medias { get; set; }

        public DbSet<LikeAccountDbModel> Accounts { get; set; }

        public DbSet<AccountToLikeMediaDbModel> AccountsToLikeMedias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProxyConfiguration());
            modelBuilder.Configurations.Add(new LikeAccountConfiguration());
            modelBuilder.Configurations.Add(new LikeMediaConfiguration());
            modelBuilder.Configurations.Add(new AccountToLikeMediaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
