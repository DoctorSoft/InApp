﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Constants;
using DataBase.Models;

namespace DataBase.Configurations
{
    public class LanguageConfiguration: EntityTypeConfiguration<LanguageDbModel>
    {
        public LanguageConfiguration(AccountName accountName)
        {
            ToTable(accountName.ToString("G") + "_Language");

            HasKey(model => model.Id);
            Property(model => model.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(model => model.Name);

            HasMany(it => it.Regions).WithRequired(model => model.Language).HasForeignKey(model => model.LanguageId);
            HasMany(it => it.Users).WithOptional(model => model.Language).HasForeignKey(model => model.LanguageId);
        }
    }
}
