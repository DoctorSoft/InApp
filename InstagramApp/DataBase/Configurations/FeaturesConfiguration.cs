using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Constants;
using DataBase.Models;

namespace DataBase.Configurations
{
    public class FeaturesConfiguration : EntityTypeConfiguration<FeaturesDbModel>
    {
        public FeaturesConfiguration(AccountName accountName)
        {
            ToTable(accountName.ToString("G") + "_Features");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.FeatureIdentyName);
            Property(model => model.IsBlocked);
        }
    }
}
