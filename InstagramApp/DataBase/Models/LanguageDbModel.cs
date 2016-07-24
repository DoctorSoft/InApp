using System.Collections.Generic;

namespace DataBase.Models
{
    public class LanguageDbModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<UserDbModel> Users { get; set; }

        public ICollection<RegionDbModel> Regions { get; set; } 
    }
}
