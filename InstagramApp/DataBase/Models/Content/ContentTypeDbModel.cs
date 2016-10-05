using System.Collections.Generic;

namespace DataBase.Models.Content
{
    public class ContentTypeDbModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<ContentDbModel> Contents { get; set; } 
    }
}
