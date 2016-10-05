using System;
using System.Collections.Generic;

namespace DataBase.Models.Content
{
    public class ContentDbModel 
    {
        public long Id { get; set; }

        public DateTime IncludingDateTime { get; set; }

        public string Link { get; set; }

        public int Order { get; set; }

        public long ContentTypeId { get; set; }

        public ContentTypeDbModel ContentType { get; set; }

        public ICollection<ContentLikesHistoryDbModel> ContentHistories { get; set; }

        public ICollection<ContentColourDbModel> ContentColours { get; set; } 
    }
}
