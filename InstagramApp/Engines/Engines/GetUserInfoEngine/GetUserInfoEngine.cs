using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Engines.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.GetUserInfoEngine
{
    public class GetUserInfoEngine : IEngine<GetUserInfoEngineModel, GetUserInfoEngineResponse>
    {
        public GetUserInfoEngineResponse Execute(RemoteWebDriver driver, GetUserInfoEngineModel model)
        {
            driver.Navigate().GoToUrl(model.UserLink);

            Thread.Sleep(500);

            var breakButtonExists = driver
                .FindElements(By.TagName("h2"))
                .Any(element => element.Text.Contains("недоступна"));

            if (breakButtonExists)
            {
                return new GetUserInfoEngineResponse();
            }

            var captchButtonExists = driver
                .FindElements(By.TagName("h2"))
                .Any(element => element.Text.Contains("Подтвердите"));

            if (captchButtonExists)
            {
                throw new CaptchaException();
            }

            var followersCount = driver
            .FindElements(By.ClassName("_s53mj"))
            .Where(element => !string.IsNullOrWhiteSpace(element.GetAttribute("href")))
            .Where(element => element.GetAttribute("href").Contains("followers"))
            .SelectMany(element => element.FindElements(By.ClassName("_bkw5z")))
            .Where(element => !string.IsNullOrWhiteSpace(element.GetAttribute("title")))
            .Select(element => int.Parse(element.GetAttribute("title").Replace(" ", "")))
            .FirstOrDefault();

            var followingCount = driver
            .FindElements(By.ClassName("_s53mj"))
            .Where(element => !string.IsNullOrWhiteSpace(element.GetAttribute("href")))
            .Where(element => element.GetAttribute("href").Contains("following"))
            .SelectMany(element => element.FindElements(By.ClassName("_bkw5z")))
            .Select(element => int.Parse(element.Text.Replace(" ", "")))
            .FirstOrDefault();

            var publicationCount = driver
            .FindElements(By.ClassName("_s53mj"))
            .Where(element => string.IsNullOrWhiteSpace(element.GetAttribute("href")))
            .SelectMany(element => element.FindElements(By.ClassName("_bkw5z")))
            .Select(element => int.Parse(element.Text.Replace(" ", "")))
            .FirstOrDefault();

            var text = driver
            .FindElements(By.ClassName("_bugdy"))
            .Where(element => string.IsNullOrWhiteSpace(element.GetAttribute("href")))
            .SelectMany(element => element.FindElements(By.TagName("span")))
            .Select(element => element.Text)
            .FirstOrDefault();

            var isStar = driver
                .FindElements(By.TagName("span"))
                .Any(element => element.Text.Contains("Подтвержденный"));

            return new GetUserInfoEngineResponse
            {
                FollowerCount = followersCount,
                FollowingCount = followingCount,
                PublicationCount = publicationCount,
                Text = text,
                IsStar = isStar
            };
        }
    }
}
