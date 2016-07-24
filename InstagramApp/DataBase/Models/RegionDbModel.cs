using System.Collections.Generic;

namespace DataBase.Models
{
    public class RegionDbModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public double MinX { get; set; }

        public double MaxX { get; set; }

        public double MinY { get; set; }

        public double MaxY { get; set; }

        public long LanguageId { get; set; }

        public ICollection<UserDbModel> Users { get; set; }

        public LanguageDbModel Language { get; set; }
    }
}
