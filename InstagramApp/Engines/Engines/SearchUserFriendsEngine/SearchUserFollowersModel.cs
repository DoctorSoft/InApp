using System;

namespace Engines.Engines.SearchUserFriendsEngine
{
    public class SearchUserFollowersModel
    {
        public string UserLink { get; set; }

        public string Id { get; set; }

        public string UserName { get; set; }

        public Action<int> ShowProcess { get; set; }
    }
}
