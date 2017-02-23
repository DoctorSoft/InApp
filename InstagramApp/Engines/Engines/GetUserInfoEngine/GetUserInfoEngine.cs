using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.GetUserInfoEngine
{
    public class GetUserInfoEngine : AbstractEngine<GetUserInfoEngineModel, GetUserInfoEngineResponse>
    {
        protected override GetUserInfoEngineResponse ExecuteEngine(RemoteWebDriver driver, GetUserInfoEngineModel model)
        {
            var client = new HttpClient();

            var page = client.GetAsync(model.UserLink.Replace("\\\\", "/")).Result.Content.ReadAsStringAsync().Result;

            var regex = new Regex("full_name[^:]*:[^\\\"]*\\\"[^\\\"]*\\\",");
            var fullName = regex.Match(page).Value.Replace("full_name", "").Replace("\"", "").Replace(",", "").Replace(":", "").Trim();

            regex = new Regex("\"biography\\\":((?!\\\",).)*");
            var biography =
                string.Join("",
                    regex.Match(page)
                        .Value.Replace("biography", "")
                        .Replace(":", "")
                        .Replace("\"", "")
                        .Replace(",", "")
                        .Replace(":", "")
                        .Replace("-", "")
                        .Split('\\', 'u')
                        .Select(item =>
                        {
                            if (string.IsNullOrWhiteSpace(item))
                            {
                                return item;
                            }

                            try
                            {
                                var parsed = Convert.ToInt32(item.Substring(0, 4), 16);

                                if (item.Length > 4)
                                {
                                    return char.ConvertFromUtf32(parsed) + item.Substring(4);
                                }
                                return char.ConvertFromUtf32(parsed);
                            }
                            catch (Exception)
                            {
                                return item;
                            }
                        })).Trim();

            regex = new Regex("is_verified[^:]*:[^,]*,");
            var verified = regex.Match(page).Value.Replace("is_verified", "").Replace("\"", "").Replace(",", "").Replace(":", "").Trim();

            regex = new Regex("language_code[^:]*:[^,]*,");
            var language = regex.Match(page).Value.Replace("language_code", "").Replace("\"", "").Replace(",", "").Replace(":", "").Trim();

            regex = new Regex("meta content=[^>]*>");
            var meta = regex.Match(page).Value;

            regex = new Regex("\"[^F]*Followers");
            var fBy = regex.Match(meta).Value.Replace("Followers", "").Replace("\"", "").Replace(",", "").Trim();

            regex = new Regex(",[^F]*Following");
            var fTo = regex.Match(meta).Value.Replace("Following", "").Replace("\"", "").Replace(",", "").Trim();

            regex = new Regex(",[^F]*Posts");
            var posts = regex.Match(meta).Value.Replace("Posts", "").Replace("\"", "").Replace(",", "").Trim();

            return new GetUserInfoEngineResponse
            {
                FollowerCount = int.Parse(fBy),
                FollowingCount = int.Parse(fTo),
                PublicationCount = int.Parse(posts),
                Text = biography,
                IsStar = bool.Parse(verified)
            };
        }
    }
}
