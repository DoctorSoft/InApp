using System;

namespace DataBase.Models
{
    public class StarRecordDbModel
    {
        public long Id { get; set; }

        public string Link { get; set; }

        public DateTime? LastFollowing { get; set; }

        public DateTime? LastUnfollowing { get; set; }

        public bool Followed { get; set; }
    }
}
