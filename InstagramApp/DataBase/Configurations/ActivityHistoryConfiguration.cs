using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Constants;
using DataBase.Models;

namespace DataBase.Configurations
{
    public class ActivityHistoryConfiguration: EntityTypeConfiguration<ActivityHistoryDbModel>
    {
        public ActivityHistoryConfiguration(AccountName accountName)
        {
            ToTable(accountName.ToString("G") + "_ActivityHistory");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.MarkDate);
            Property(model => model.FollowersCount);
        }
    }
}
