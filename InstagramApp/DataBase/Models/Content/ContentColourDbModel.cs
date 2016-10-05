namespace DataBase.Models.Content
{
    public class ContentColourDbModel
    {
        public long Id { get; set; }

        public ColourDbModel Colour { get; set; }

        public ContentDbModel Content { get; set; }

        public long ColourId { get; set; }

        public long ContentId { get; set; }
    }
}
