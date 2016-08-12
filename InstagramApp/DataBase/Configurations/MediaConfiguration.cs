using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Constants;
using DataBase.Models;

namespace DataBase.Configurations
{
    public class MediaConfiguration: EntityTypeConfiguration<MediaDbModel>
    {
        public MediaConfiguration(AccountName accountName)
        {
            ToTable(accountName.ToString("G") + "_Media");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.Link);
            Property(model => model.MediaStatus);
            Property(model => model.X);
            Property(model => model.Y);

            HasOptional(it => it.User).WithMany(model => model.Medias).HasForeignKey(link => link.UserId);
        }
    }
}
