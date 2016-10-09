namespace DataBase.Models.LikeApplication
{
    public class AccountToLikeMediaDbModel
    {
        public long Id { get; set; }

        public long LikeAccountId { get; set; }

        public long LikeMediaId { get; set; }

        public LikeAccountDbModel LikeAccount { get; set; }

        public LikeMediaDbModel LikeMedia { get; set; }
    }
}
