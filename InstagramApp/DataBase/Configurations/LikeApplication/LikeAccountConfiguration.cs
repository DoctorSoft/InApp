using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DataBase.Models.LikeApplication;

namespace DataBase.Configurations.LikeApplication
{
    public class LikeAccountConfiguration: EntityTypeConfiguration<LikeAccountDbModel>
    {
        public LikeAccountConfiguration()
        {
            ToTable("LikeApplication_LikeAccount");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.Email);
            Property(model => model.Link);
            Property(model => model.Name);
            Property(model => model.Password);

            HasMany(it => it.AccountToLikeMedias).WithRequired(model => model.LikeAccount).HasForeignKey(model => model.LikeAccountId);
        }
    }
}
