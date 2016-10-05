using System;

namespace DataBase.Models.Content
{
    public class ContentLikesHistoryDbModel
    {
        public long Id { get; set; }

        public DateTime CheckingDateTime { get; set; }

        public int LikeCount { get; set; }

        public long ContentId { get; set; }

        public ContentDbModel Content { get; set; }
    }
}
