using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;
using DataBase.Models;

namespace DataBase.Contexts.InnerTools
{
    public interface ISettingsContext
    {
        AccountName GetAccountName();

        DbSet<ProfileSettingsDbModel> ProfileSettings { get; set; }

        int SaveChanges();
    }
}
