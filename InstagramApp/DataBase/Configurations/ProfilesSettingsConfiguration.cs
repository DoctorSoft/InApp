using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DataBase.Models;

namespace DataBase.Configurations
{
    public class ProfilesSettingsConfiguration: EntityTypeConfiguration<ProfilesSettingsDbModel>
    {
        public ProfilesSettingsConfiguration()
        {
            ToTable("ProfilesSettings");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.Login);
            Property(model => model.Password);
            Property(model => model.HomePageUrl);
        }
    }
}
