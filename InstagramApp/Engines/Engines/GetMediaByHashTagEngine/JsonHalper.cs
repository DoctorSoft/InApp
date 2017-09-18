using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Engines.Engines.GetMediaByHashTagEngine
{
    public static class JsonHalper
    {

        public static dynamic GetJson(string page)
        {
            dynamic data;

            var queryIdRegex = new Regex("{\"activity_counts\"(.*?)\"show_app_install\": true}");

            var match = queryIdRegex.Match(page).Value;
            var javaScriptSerializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
            if (!match.Equals(string.Empty))
            {
                data = javaScriptSerializer.DeserializeObject(match);
                return data;
            }

            data = javaScriptSerializer.DeserializeObject(page);
            return data;
        }

        public static List<string> GetUsersIdTopImages(dynamic jsonData)
        {
            var tagPages = jsonData["entry_data"]["TagPage"];
            var tagPage = tagPages[0];

            var topImages = tagPage["tag"]["top_posts"]["nodes"];

            var result = GetOwnerId(topImages);

            return result;
        }

        public static List<string> GetSrcTopImages(dynamic jsonData)
        {
            var tagPages = jsonData["entry_data"]["TagPage"];
            var tagPage = tagPages[0];

            var topImages = tagPage["tag"]["top_posts"]["nodes"];

            var result = GetImageSrcs(topImages);

            return result;
        }

        public static List<string> GetUsersIdNewImages(dynamic jsonData)
        {
            var tagPages = jsonData["entry_data"]["TagPage"];
            var tagPage = tagPages[0];

            var newImages = tagPage["tag"]["media"]["nodes"];

            var result = GetOwnerId(newImages);

            return result;
        }

        public static List<string> GetSrcNewImages(dynamic jsonData)
        {
            var tagPages = jsonData["entry_data"]["TagPage"];
            var tagPage = tagPages[0];

            var newImages = tagPage["tag"]["media"]["nodes"];

            var result = GetImageSrcs(newImages);

            return result;
        }

        public static string GetEndCursor(dynamic jsonData)
        {
            var tagPages = jsonData["entry_data"]["TagPage"];
            var tagPage = tagPages[0];

            var endCursors = tagPage["tag"]["media"]["page_info"];
            foreach (var section in endCursors)
            {
                if (!section.Key.Equals("end_cursor"))
                {
                    continue;
                }

                var endCursorElement = section.Value;
                return endCursorElement.ToString();
            }

            return null;
        }

        public static List<string> GetSrcNewImagesForApi(dynamic jsonData)
        {
            var tagPages = jsonData["data"]["hashtag"]["edge_hashtag_to_media"]["edges"];

            var result = new List<string>();

            foreach (var newImageSection in tagPages)
            {
                foreach (var sections in newImageSection["node"])
                {
                    if (!sections.Key.Equals("shortcode"))
                    {
                        continue;
                    }

                    var srcElement = sections.Value;
                    var imageSrc = string.Format("https://www.instagram.com/p/{0}/", srcElement.ToString());
                    result.Add(imageSrc);

                    break;
                }
            }

            return result;
        }

        public static List<string> GetUsersIdNewImagesForApi(dynamic jsonData)
        {
            var tagPages = jsonData["data"]["hashtag"]["edge_hashtag_to_media"]["edges"];

            var result = new List<string>();

            foreach (var newImageSection in tagPages)
            {
                foreach (var sections in newImageSection)
                {
                    foreach (var section in sections)
                    {
                        foreach (var subSection in section)
                        {
                            if (!subSection.Key.Equals("owner"))
                            {
                                continue;
                            }

                            var idElement = subSection.Value;
                            foreach (var id in idElement)
                            {
                                var idValue = id.ToString();
                                result.Add(idValue.Value);
                                break;
                            }
                            break;
                        }
                    }
                }
            }

            return result;
        }

        private static List<string> GetOwnerId(dynamic inputSection)
        {
            var result = new List<string>();

            foreach (var newImageSection in inputSection)
            {
                foreach (var section in newImageSection)
                {
                    if (!section.Key.Equals("owner"))
                    {
                        continue;
                    }

                    var owner = section.Value;
                    var ownerId = owner["id"];
                    var id = ownerId.ToString();

                    result.Add(id);
                }
            }

            return result;
        }

        private static List<string> GetImageSrcs(dynamic inputSection)
        {
            var result = new List<string>();

            foreach (var newImageSection in inputSection)
            {
                foreach (var section in newImageSection)
                {
                    if (!section.Key.Equals("code"))
                    {
                        continue;
                    }

                    var src = section.Value;
                    var imageSrc = string.Format("https://www.instagram.com/p/{0}/", src.ToString());

                    result.Add(imageSrc);
                }
            }

            return result;
        }
    }
}
