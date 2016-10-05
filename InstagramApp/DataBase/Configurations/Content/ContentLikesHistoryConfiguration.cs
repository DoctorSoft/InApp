using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Constants;
using DataBase.Models.Content;

namespace DataBase.Configurations.Content
{
    public class ContentLikesHistoryConfiguration: EntityTypeConfiguration<ContentLikesHistoryDbModel>
    {
        public ContentLikesHistoryConfiguration(AccountName accountName)
        {
            ToTable(accountName.ToString("G") + "_ContentLikesHistory");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.CheckingDateTime);
            Property(model => model.LikeCount);

            HasRequired(it => it.Content).WithMany(model => model.ContentHistories).HasForeignKey(model => model.ContentId);
        }
    }
}
