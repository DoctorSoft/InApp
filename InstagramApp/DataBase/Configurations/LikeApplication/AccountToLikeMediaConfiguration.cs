using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DataBase.Models.LikeApplication;

namespace DataBase.Configurations.LikeApplication
{
    public class ProxyConfiguration: EntityTypeConfiguration<ProxyDbModel>
    {
        public ProxyConfiguration()
        {
            ToTable("LikeApplication_Proxy");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.IpAddress);
            Property(model => model.Port);
        }
    }
}
