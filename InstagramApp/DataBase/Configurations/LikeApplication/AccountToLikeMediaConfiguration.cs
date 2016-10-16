using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DataBase.Models.LikeApplication;

namespace DataBase.Configurations.LikeApplication
{
    public class AccountToLikeMediaConfiguration : EntityTypeConfiguration<AccountToLikeMediaDbModel>
    {
        public AccountToLikeMediaConfiguration()
        {
            ToTable("LikeApplication_AccountToLikeMedia");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(it => it.LikeAccount).WithMany(model => model.AccountToLikeMedias).HasForeignKey(model => model.LikeAccountId);
            HasRequired(it => it.LikeMedia).WithMany(model => model.AccountToLikeMedias).HasForeignKey(model => model.LikeMediaId);
        }
    }
}
