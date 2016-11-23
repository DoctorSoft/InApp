using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Constants;
using DataBase.Models.Content;

namespace DataBase.Configurations.Content
{
    public class ContentTypeConfiguration: EntityTypeConfiguration<ContentTypeDbModel>
    {
        public ContentTypeConfiguration(AccountName accountName)
        {
            ToTable("__" + accountName.ToString("G") + "_ContentType");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.Name);

            HasMany(it => it.Contents).WithRequired(model => model.ContentType).HasForeignKey(model => model.ContentTypeId);
        }
    }
}
