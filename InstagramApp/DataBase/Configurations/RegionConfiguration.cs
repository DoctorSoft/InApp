using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Constants;
using DataBase.Models;

namespace DataBase.Configurations
{
    public class RegionConfiguration: EntityTypeConfiguration<RegionDbModel>
    {
        public RegionConfiguration(AccountName accountName)
        {
            ToTable(accountName.ToString("G") + "_Region");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.Name);
            Property(model => model.MaxX);
            Property(model => model.MaxY);
            Property(model => model.MinX);
            Property(model => model.MinY);

            HasMany(it => it.Users).WithOptional(model => model.Region).HasForeignKey(model => model.RegionId);
            HasRequired(it => it.Language).WithMany(model => model.Regions).HasForeignKey(model => model.LanguageId);
        }
    }
}
