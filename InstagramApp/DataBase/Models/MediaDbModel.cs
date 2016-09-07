using System;
using Constants;

namespace DataBase.Models
{
    public class MediaDbModel
    {
        public long Id { get; set; }

        public string Link { get; set; }

        public MediaStatus MediaStatus { get; set; }

        public double? X { get; set; }

        public double? Y { get; set; }

        public long? UserId { get; set; }

        public DateTime? LikeDate { get; set; }

        public bool HasComment { get; set; }

        public UserDbModel User { get; set; } 
    }
}
