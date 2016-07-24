using System;
using System.Collections.Generic;
using Constants;

namespace DataBase.Models
{
    public class UserDbModel
    {
        public long Id { get; set; }

        public string Link { get; set; }

        public bool ConfirmedByAdmin { get; set; }

        public UserStatus UserStatus { get; set; }

        public long? RegionId { get; set; }

        public long? LanguageId { get; set; }

        public DateTime? IncludingTime { get; set; }

        public RegionDbModel Region { get; set; }

        public LanguageDbModel Language { get; set; }

        public ICollection<MediaDbModel> Medias { get; set; } 
    }
}
