using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DataBase.Models.LikeApplication;

namespace DataBase.Configurations.LikeApplication
{
    public class LikeMediaConfiguration: EntityTypeConfiguration<LikeMediaDbModel>
    {
        public LikeMediaConfiguration()
        {
            ToTable("LikeApplication_LikeMedia");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.Link);

            HasMany(it => it.AccountToLikeMedias).WithRequired(model => model.LikeMedia).HasForeignKey(model => model.LikeMediaId);
        }
    }
}
