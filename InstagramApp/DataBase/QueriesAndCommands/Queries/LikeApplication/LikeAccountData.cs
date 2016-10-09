using System.Collections.Generic;

namespace DataBase.QueriesAndCommands.Queries.LikeApplication
{
    public class LikeAccountData
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public List<string> MediasToLike { get; set; } 
    }
}
