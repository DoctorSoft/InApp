using System.Collections.Generic;

namespace DataBase.Models.LikeApplication
{
    public class LikeAccountDbModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<AccountToLikeMediaDbModel> AccountToLikeMedias { get; set; } 
    }
}
