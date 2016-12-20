using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Constants;
using DataBase.Models;

namespace DataBase.Configurations
{
    public class StarRecordConfiguration : EntityTypeConfiguration<StarRecordDbModel>
    {
        public StarRecordConfiguration(AccountName accountName)
        {
            ToTable("__" + accountName.ToString("G") + "_StarRecord");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.Followed);
            Property(model => model.LastFollowing);
            Property(model => model.LastUnfollowing);
            Property(model => model.Link);
        }
    }
}
