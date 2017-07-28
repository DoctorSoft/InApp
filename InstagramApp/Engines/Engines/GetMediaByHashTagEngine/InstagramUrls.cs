namespace Engines.Engines.GetMediaByHashTagEngine
{
    public static class InstagramUrls
    {
        public static string SeachByHashTag(string tagName)
        {
            return string.Format("https://www.instagram.com/explore/tags/{0}/", tagName);
        }

        public static string SeachByHashTagApi(string tagName, long topCount, string endCursor)
        {
            var seachByHashTag =
                string.Format("https://www.instagram.com/graphql/query/?query_id=17875800862117404&variables=%7B%22tag_name%22%3A%22{0}%22%2C%22first%22%3A{1}%2C%22after%22%3A%22{2}%22%7D", tagName, topCount, endCursor);
            return seachByHashTag;
        } 
    }
}
