using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Constants;
using DataBase.Models;

namespace DataBase.Configurations
{
    public class HashTagConfiguration: EntityTypeConfiguration<HashTagDbModel>
    {
        public HashTagConfiguration(AccountName accountName)
        {
            ToTable("__" + accountName.ToString("G") + "_HashTag");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.Name);
        }
    }
}
