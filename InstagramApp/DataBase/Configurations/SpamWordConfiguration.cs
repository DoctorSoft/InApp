using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Constants;
using DataBase.Models;

namespace DataBase.Configurations
{
    public class SpamWordConfiguration: EntityTypeConfiguration<SpamWordDbModel>
    {
        public SpamWordConfiguration(AccountName accountName)
        {
            ToTable(accountName.ToString("G") + "_SpamWord");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.WordRoot);
            Property(model => model.SpamFactor);
        }
    }
}
