using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Constants;
using DataBase.Models.Content;

namespace DataBase.Configurations.Content
{
    public class ColourConfiguration: EntityTypeConfiguration<ColourDbModel>
    {
        public ColourConfiguration(AccountName accountName)
        {
            ToTable("__" + accountName.ToString("G") + "_Colour");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.Name);

            HasMany(it => it.ContentColours).WithRequired(model => model.Colour).HasForeignKey(model => model.ColourId);
        }
    }
}
