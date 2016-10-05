using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;
using DataBase.Models.Content;

namespace DataBase.Configurations.Content
{
    public class ContentColourConfiguration: EntityTypeConfiguration<ContentColourDbModel>
    {
        public ContentColourConfiguration(AccountName accountName)
        {
            ToTable(accountName.ToString("G") + "_ContentColour");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(it => it.Content).WithMany(model => model.ContentColours).HasForeignKey(model => model.ContentId);
            HasRequired(it => it.Colour).WithMany(model => model.ContentColours).HasForeignKey(model => model.ColourId);
        }
    }
}
