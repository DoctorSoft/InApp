using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Constants;
using DataBase.Models;

namespace DataBase.Configurations
{
    public class FunctionalityConfiguration : EntityTypeConfiguration<FunctionalityDbModel>
    {
        public FunctionalityConfiguration(AccountName accountName)
        {
            ToTable("__" + accountName.ToString("G") + "_Functionality");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.ApplyInterval);
            Property(model => model.FunctionalityName);
            Property(model => model.FunctionalityNumber);
            Property(model => model.LastApplied);
            Property(model => model.Token);
        }
    }
}
