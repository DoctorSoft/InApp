using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Constants;
using DataBase.Models;

namespace DataBase.Configurations
{
    public class FunctionalityReportConfiguration: EntityTypeConfiguration<FunctionalityReportDbModel>
    {
        public FunctionalityReportConfiguration(AccountName accountName)
        {
            ToTable(accountName.ToString("G") + "_FunctionalityReport");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.EndDateTime);
            Property(model => model.StartDateTime);
            Property(model => model.JsonText);
        }
    }
}
