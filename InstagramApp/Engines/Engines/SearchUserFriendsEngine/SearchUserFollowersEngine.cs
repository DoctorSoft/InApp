using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Helpers;
using Engines.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using RestSharp;

namespace Engines.Engines.SearchUserFriendsEngine
{
    public class SearchUserFollowersEngine : AbstractEngine<SearchUserFollowersModel, List<string>>
    {
        private IEnumerable<string> ParseFromResponse(string response)
        {
            var pattern = "username[^,]*";
            var regex = new Regex(pattern);

            foreach (Match line in regex.Matches(response))
            {
                if (!string.IsNullOrWhiteSpace(line.Value))
                {
                    var result = Path.Combine("https://www.instagram.com", line.Value.Split('\"')[2]);
                    yield return result;
                }
            }
        }

        protected override List<string> ExecuteEngine(RemoteWebDriver driver, SearchUserFollowersModel model)
        {
            if (!base.NavigateToUrl(driver, model.UserLink))
            {
                return GetDefaultResult();
            } 
            
            Thread.Sleep(3000);

            var breakButtonExists = driver
                .FindElements(By.TagName("h2"))
                .Any(element => element.Text.Contains("недоступна")); 

            if (breakButtonExists)
            {
                return new List<string>();
            }

            var captchButtonExists = driver
                .FindElements(By.TagName("h2"))
                .Any(element => element.Text.Contains("Подтвердите")); 

            if (captchButtonExists)
            {
                throw new CaptchaException();
            }

            /*var followersButton = driver
            .FindElements(By.ClassName("_s53mj"))
            .Where(element =>
            {
                if (element.GetAttribute("href") != null)
                {
                    return element.GetAttribute("href").ToLower().Contains("followers");
                }
                return false;
            })
            .FirstOrDefault();

            try
            {
                followersButton.Click();
            }
            catch (Exception)
            {
                return new List<string>();
            }

            Thread.Sleep(3500);

            var window = driver
                .FindElements(By.TagName("li"))
                .First(element => element.GetAttribute("class") == "_cx1ua");

            window.Click();*/

            /*Thread.Sleep(1500);

            for (var i = 0; i < 3; i++)
            {
                Thread.Sleep(100);
                driver.Keyboard.SendKeys(Keys.PageDown);
            }*/

            //

            var hasNextPage = true;
            string endCursor = null;
            var userList = new List<string>();

            var allCookies = driver.Manage().Cookies;
            var cookies = "mid" + "=" + allCookies.GetCookieNamed("mid").Value + "; " +
                          "sessionid" + "=" + allCookies.GetCookieNamed("sessionid").Value + "; " +
                          "csrftoken" + "=" + allCookies.GetCookieNamed("csrftoken").Value + "; " +
                          "s_network" + "=" + allCookies.GetCookieNamed("s_network").Value + "; " +
                          "ds_user_id" + "=" + allCookies.GetCookieNamed("ds_user_id").Value + "; " +
                          "ig_pr" + "=" + allCookies.GetCookieNamed("ig_pr").Value + "; " +
                          "ig_vw" + "=" + allCookies.GetCookieNamed("ig_vw").Value + "; ";

            cookies = cookies + cookies;

            var allcookies = driver.Manage().Cookies;
            var csfToken = allcookies.GetCookieNamed("csrftoken").Value;

            var clientRest = new RestClient("https://www.instagram.com/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var requestRest = new RestRequest(model.UserName + "/", Method.GET);

            requestRest.AddCookie("mid", allCookies.GetCookieNamed("mid").Value);
            requestRest.AddCookie("sessionid", allCookies.GetCookieNamed("sessionid").Value);
            requestRest.AddCookie("csrftoken", allCookies.GetCookieNamed("csrftoken").Value);
            requestRest.AddCookie("s_network", allCookies.GetCookieNamed("s_network").Value);
            requestRest.AddCookie("ds_user_id", allCookies.GetCookieNamed("ds_user_id").Value);
            requestRest.AddCookie("ig_pr", allCookies.GetCookieNamed("ig_pr").Value);
            requestRest.AddCookie("ig_vw", allCookies.GetCookieNamed("ig_vw").Value);

            // easily add HTTP Headers
            requestRest.AddHeader("Origin", "https://www.instagram.com");
            requestRest.AddHeader("Referer", "https://www.instagram.com/" + model.UserName + "/followers/");
            requestRest.AddHeader("X-Instagram-AJAX", "1");
            requestRest.AddHeader("User-Agent",
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36");
            requestRest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            requestRest.AddHeader("X-Requested-With", "XMLHttpRequest");
            requestRest.AddHeader("X-CSRFToken", csfToken);
            requestRest.AddHeader("Accept-Encoding", "gzip, deflate, br");
            requestRest.AddHeader("Accept-Language", "ru-RU,ru;q=0.8,en-US;q=0.6,en;q=0.4");
            requestRest.AddHeader("Cookie", cookies);

            // execute the request
            //IRestResponse responseRest = clientRest.Execute(requestRest);
            //var content = responseRest.Content; // 

            //var regex = new Regex("end_cursor[^:]*:[^}]*");
            //var preCodeResult = regex.Match(content).Value;
            //"end_cursor\": \"AQDzfnfVpquG8r-0M1OHjiaVr2lxYPuQJzZYJQU1BAuQBsjIstiuBQMgYo9c70_q6rEFwwnPFbMczCgiHHkI_oYUO-OWCR_0TOPY-BW99AkRDw\""

            //endCursor = null; //preCodeResult.Split(':').Last().Split('\"')[1];

            // getting owner id
            //var ownerId = allCookies.GetCookieNamed("ds_user_id").Value;//preOwnerIdResult.Split(':').Last().Split('\"')[1];

            while (hasNextPage)
            {
                /*https://www.instagram.com/graphql/query/?query_id=17851374694183129&id=3219547324&first=10
                 * 
                 * 
                 * https://www.instagram.com/graphql/query/?query_id=17874545323001329&id=3219547324&first=10
                 * 
                 * GET
                 https://www.instagram.com/graphql/query/?
                 * query_id=17851374694183129& 
                 * id=2215418832&
                 * first=100&
                 * after=AQABy8iIQKxjl3JO5POUC8OKBSvt-djTUPixEi9MH5cAxUys0lOtYnjA-Vh3gh7jPkNy60w4eK89pVYsatPWYNE-Q2nyuh-Us7DTR5PTZ6nKkQ
                 */

                /*
                 * https://www.instagram.com/graphql/query/?query_id=17851374694183129&id=3219547324&first=20
                 */

                /*
                 * https://www.instagram.com/graphql/query/?
                 * query_id=17851374694183129&
                 * id=3152872290&
                 * first=100&
                 * after=AQB4fsn_VhdvEpK0RaflCu_05jL4jOg-KZOyuKtZghmRvnvgLTkcKTToP3n3aaFuF-yxB8QVjS8SixI-kSw7-WBCoLliCCfn1SOBP3AfHJdMLA
                 */

                clientRest = new RestClient("https://www.instagram.com/");
                // client.Authenticator = new HttpBasicAuthenticator(username, password);

                // first request
                //https://www.instagram.com/graphql/query/?query_id=17845312237175864&id=3219547324

                if (endCursor == null)
                {
                    requestRest = new RestRequest("graphql/query/?query_id=" + /*model.MyId*/"17851374694183129" + "&id=" + model.Id + "&first=100", Method.GET);
                }
                else {
                    requestRest = new RestRequest("graphql/query/?query_id=" + /*model.MyId*/"17851374694183129" + "&id=" + model.Id + "&first=100&after=" + endCursor, Method.GET);
                }

                requestRest.Parameters.Clear();

                //requestRest.AddParameter("q", queryString);
                //requestRest.AddParameter("ref", "relationships::follow_list");

                // add parameters for all properties on an object
                requestRest.AddCookie("mid", allCookies.GetCookieNamed("mid").Value);
                requestRest.AddCookie("sessionid", allCookies.GetCookieNamed("sessionid").Value);
                requestRest.AddCookie("csrftoken", allCookies.GetCookieNamed("csrftoken").Value);
                requestRest.AddCookie("s_network", allCookies.GetCookieNamed("s_network").Value);
                requestRest.AddCookie("ds_user_id", allCookies.GetCookieNamed("ds_user_id").Value);
                requestRest.AddCookie("ig_pr", allCookies.GetCookieNamed("ig_pr").Value);
                requestRest.AddCookie("ig_vw", allCookies.GetCookieNamed("ig_vw").Value);

                // easily add HTTP Headers
                requestRest.AddHeader("Origin", "https://www.instagram.com");
                requestRest.AddHeader("Referer", "https://www.instagram.com/" + model.UserName + "/followers/");
                requestRest.AddHeader("X-Instagram-AJAX", "1");
                requestRest.AddHeader("User-Agent",
                    "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36");
                requestRest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                requestRest.AddHeader("X-Requested-With", "XMLHttpRequest");
                requestRest.AddHeader("X-CSRFToken", csfToken);
                requestRest.AddHeader("Accept-Encoding", "gzip, deflate, br");
                requestRest.AddHeader("Accept-Language", "ru-RU,ru;q=0.8,en-US;q=0.6,en;q=0.4");
                requestRest.AddHeader("Cookie", cookies);

                // execute the request
                IRestResponse responseRest = clientRest.Execute(requestRest);
                var content = responseRest.Content; // 

                userList = userList.Union(ParseFromResponse(content)).ToList();
                dynamic data = Json.Decode(content);;
                try
                {
                    var follows = data.data.user.edge_followed_by;
                    //var count = int.Parse(follows.count.ToString());
                    var pageInfo = follows.page_info;
                    endCursor = pageInfo.end_cursor.ToString();
                    hasNextPage = bool.Parse(pageInfo.has_next_page.ToString());
                }
                catch (Exception exception)
                {
                    return userList;
                }

                Thread.Sleep(500);

                if (model.ShowProcess != null)
                {
                    model.ShowProcess(userList.Count);
                }
            }

            driver.Keyboard.SendKeys(Keys.Escape);

            return userList;
        }
    }
}
