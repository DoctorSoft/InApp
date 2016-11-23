using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Constants;
using DataBase.Models;

namespace DataBase.Configurations
{
    public class UserConfiguration: EntityTypeConfiguration<UserDbModel>
    {
        public UserConfiguration(AccountName accountName)
        {
            ToTable("__" + accountName.ToString("G") + "_User");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.ConfirmedByAdmin);
            Property(model => model.FriendsWereSearched);
            Property(model => model.IncludingTime);
            Property(model => model.Link);
            Property(model => model.UserStatus);

            HasOptional(it => it.Language).WithMany(model => model.Users).HasForeignKey(model => model.LanguageId);
            HasOptional(it => it.Region).WithMany(model => model.Users).HasForeignKey(model => model.RegionId);
            HasMany(it => it.Medias).WithOptional(link => link.User).HasForeignKey(link => link.UserId);
        }
    }
}
