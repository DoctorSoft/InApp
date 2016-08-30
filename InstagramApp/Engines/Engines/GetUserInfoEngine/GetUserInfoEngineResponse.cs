namespace Engines.Engines.GetUserInfoEngine
{
    public class GetUserInfoEngineResponse
    {
        public string Text { get; set; }

        public int FollowingCount { get; set; }

        public int FollowerCount { get; set; }

        public int PublicationCount { get; set; }

        public bool IsStar { get; set; }
    }
}
