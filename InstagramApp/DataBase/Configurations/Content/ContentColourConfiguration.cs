using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Constants;
using DataBase.Models.Content;

namespace DataBase.Configurations.Content
{
    public class ContentColourConfiguration: EntityTypeConfiguration<ContentColourDbModel>
    {
        public ContentColourConfiguration(AccountName accountName)
        {
            ToTable("__" + accountName.ToString("G") + "_ContentColour");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(it => it.Content).WithMany(model => model.ContentColours).HasForeignKey(model => model.ContentId);
            HasRequired(it => it.Colour).WithMany(model => model.ContentColours).HasForeignKey(model => model.ColourId);
        }
    }
}
