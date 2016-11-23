using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Constants;
using DataBase.Models;

namespace DataBase.Configurations
{
    public class ProfilesSettingsConfiguration: EntityTypeConfiguration<ProfileSettingsDbModel>
    {
        public ProfilesSettingsConfiguration(AccountName accountName)
        {
            ToTable("__" + accountName.ToString("G") + "_ProfilesSettings");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.Login);
            Property(model => model.Password);
            Property(model => model.HomePageUrl);
            Property(model => model.PreviousFollowingsSynchDate);
        }
    }
}
