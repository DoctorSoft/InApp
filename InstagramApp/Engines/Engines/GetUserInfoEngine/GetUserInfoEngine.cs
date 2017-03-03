using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.GetUserInfoEngine
{
    public class GetUserInfoEngine : AbstractEngine<GetUserInfoEngineModel, GetUserInfoEngineResponse>
    {
        protected override GetUserInfoEngineResponse ExecuteEngine(RemoteWebDriver driver, GetUserInfoEngineModel model)
        {
            HttpClient client;
            string page = string.Empty;
            string biography;
            string verified;
            string meta;
            string fBy;
            string fTo;
            string posts;
            HttpResponseMessage message;
            int attempt = 0;
            bool passed = false;
            string url = model.UserLink.Replace("\\", "/");
            string name = string.Empty;

            try
            {
                client = new HttpClient();

                attempt = 0;
                const int maxAttempts = 2;

                while (!passed)
                {
                    try
                    {
                        message = client.GetAsync(url).Result;
                        page = message.Content.ReadAsStringAsync().Result;
                        passed = true;
                    }
                    catch (Exception)
                    {
                        attempt++;
                        Thread.Sleep(attempt * 500);
                        if (attempt > maxAttempts)
                        {
                            throw;
                        }
                    }
                }

                var regex = new Regex("full_name[^:]*:[^\\\"]*\\\"[^\\\"]*\\\",");
                name =
                    regex.Match(page)
                        .Value.Replace("full_name", "")
                        .Replace("\"", "")
                        .Replace(",", "")
                        .Replace(":", "")
                        .Trim();

                regex = new Regex("\"biography\\\":((?!\\\",).)*");

                biography = regex.Match(page).Value;

                if (!biography.Contains("null"))
                {
                    biography =
                    string.Join("", biography.Replace("\"biography\":", "")
                            .Replace("script", "")
                            .Replace("\"", "")
                            .Split('\\')
                            .Select(item =>
                            {
                                if (string.IsNullOrWhiteSpace(item))
                                {
                                    return item;
                                }

                                try
                                {
                                    if (item.First() != 'u')
                                    {
                                        return item;
                                    }

                                    item = item.Remove(0, 1);
                                    var parsed = Convert.ToInt32(item.Substring(0, 4), 16);

                                    if (item.Length > 4)
                                    {
                                        return char.ConvertFromUtf32(parsed) + item.Substring(4);
                                    }
                                    return char.ConvertFromUtf32(parsed);
                                }
                                catch (Exception ex)
                                {
                                    return " ";
                                }
                            })).Trim();

                    biography =
                        new string(
                            biography.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c) || char.IsPunctuation(c))
                                .ToArray()).Trim();
                }
                else
                {
                    biography = null;
                }
                
                regex = new Regex("is_verified[^:]*:[^,]*,");
                verified =
                    regex.Match(page)
                        .Value.Replace("is_verified", "")
                        .Replace("\"", "")
                        .Replace(",", "")
                        .Replace(":", "")
                        .Trim();

                regex = new Regex("language_code[^:]*:[^,]*,");
                var language =
                    regex.Match(page)
                        .Value.Replace("language_code", "")
                        .Replace("\"", "")
                        .Replace(",", "")
                        .Replace(":", "")
                        .Trim();

                regex = new Regex("meta((?!content).)*content[^>]*Followers[^>]*>");
                meta = regex.Match(page).Value;

                regex = new Regex("\"[^F]*Followers");
                fBy =regex.Match(meta).Value.Replace("Followers", "")
                        .Replace("\"", "")
                        .Replace(",", "")
                        .Replace("description", "")
                        .Replace("content", "")
                        .Replace("=", "")
                        .Trim();

                regex = new Regex(",[^F]*Following");
                fTo = regex.Match(meta).Value.Replace("Following", "")
                    .Replace("\"", "")
                        .Replace(",", "")
                        .Replace("description", "")
                        .Replace("content", "")
                        .Replace("=", "")
                        .Trim();

                regex = new Regex(",[^F]*Posts");
                posts = regex.Match(meta).Value.Replace("Posts", "")
                    .Replace("\"", "")
                        .Replace(",", "")
                        .Replace("description", "")
                        .Replace("content", "")
                        .Replace("=", "")
                        .Trim();

                var followerCount = fBy.ToLower().Contains("k") ? double.Parse(fBy.ToLower().Replace("k", "").Replace(".", ",")) * 1000 : 
                                    fBy.ToLower().Contains("m") ? double.Parse(fBy.ToLower().Replace("m", "").Replace(".", ",")) * 1000000 :
                                    double.Parse(fBy);

                var followingCount = fTo.ToLower().Contains("k") ? double.Parse(fTo.ToLower().Replace("k", "").Replace(".", ",")) * 1000 :
                                    fTo.ToLower().Contains("m") ? double.Parse(fTo.ToLower().Replace("m", "").Replace(".", ",")) * 1000000 :
                                    double.Parse(fTo);

                return new GetUserInfoEngineResponse
                {
                    FollowerCount = (int)followerCount,
                    FollowingCount = (int)followingCount,
                    PublicationCount = int.Parse(posts),
                    Text = biography,
                    IsStar = verified.ToLower().Contains("true"),
                    Page = page,
                    Name = name
                };

            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}
