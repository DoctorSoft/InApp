using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Constants;
using DataBase.Models.Content;

namespace DataBase.Configurations.Content
{
    public class ContentConfiguration : EntityTypeConfiguration<ContentDbModel>
    {
        public ContentConfiguration(AccountName accountName)
        {
            ToTable("__" + accountName.ToString("G") + "_Content");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.IncludingDateTime);
            Property(model => model.Link);
            Property(model => model.Order);

            HasMany(it => it.ContentColours).WithRequired(model => model.Content).HasForeignKey(model => model.ContentId);
            HasMany(it => it.ContentHistories).WithRequired(model => model.Content).HasForeignKey(model => model.ContentId);
            HasRequired(it => it.ContentType).WithMany(model => model.Contents).HasForeignKey(model => model.ContentTypeId);
        }
    }
}
