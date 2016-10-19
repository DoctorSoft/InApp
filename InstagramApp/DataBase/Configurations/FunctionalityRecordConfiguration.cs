using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Constants;
using DataBase.Models;

namespace DataBase.Configurations
{
    public class FunctionalityRecordConfiguration : EntityTypeConfiguration<FunctionalityRecordDbModel>
    {
        public FunctionalityRecordConfiguration(AccountName accountName)
        {
            ToTable(accountName.ToString("G") + "_FunctionalityRecord");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.Name);
            Property(model => model.DateTime);
            Property(model => model.Note);
            Property(model => model.WorkStatus);
        }
    }
}
