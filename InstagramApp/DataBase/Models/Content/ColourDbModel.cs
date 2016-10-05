using System.Collections.Generic;

namespace DataBase.Models.Content
{
    public class ColourDbModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<ContentColourDbModel> ContentColours { get; set; } 
    }
}
