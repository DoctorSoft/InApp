using System.Collections.Generic;

namespace DataBase.Models.LikeApplication
{
    public class LikeMediaDbModel
    {
        public long Id { get; set; }

        public string Link { get; set; }

        public ICollection<AccountToLikeMediaDbModel> AccountToLikeMedias { get; set; } 
    }
}
