using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DataBase.Contexts;
using DataBase.QueriesAndCommands;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.SearchUserFriendsEngine
{
    public class SearchUserFriendsEngine : IEngine<SearchUserFriendsModel, List<string>>
    {
        public List<string> Execute(RemoteWebDriver driver, SearchUserFriendsModel model)
        {
            driver.Navigate().GoToUrl(model.UserPageLink);

            Thread.Sleep(500);

            var breakButtonExists = driver
                .FindElements(By.TagName("h2"))
                .Any(element => element.Text.Contains("недоступна"));

            if (breakButtonExists)
            {
                return new List<string>();
            }

            var count =  driver
            .FindElements(By.ClassName("_bkw5z"))
            .Where(element => element.TagName.Contains("span"))
            .Where(element => !string.IsNullOrWhiteSpace(element.GetAttribute("title")))
            .Select(element => int.Parse(element.GetAttribute("title").Replace(" ", "")))
            .Single();

            var followersButton = driver
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

            Thread.Sleep(1500);

            var window = driver
                .FindElements(By.TagName("li"))
                .First(element => element.GetAttribute("class") == "_cx1ua");

            window.Click();

            Thread.Sleep(500);

            var realCount = model.MaxCount == null ? count : Math.Min(count, model.MaxCount.Value);
            for (var i = 0; i < realCount; i++)
            {
                Thread.Sleep(100);
                driver.Keyboard.SendKeys(Keys.PageDown);
            }

            var userList = driver
            .FindElements(By.ClassName("_4zhc5"))  
            .Where(element => element.TagName == "a")
            .Where(element => element.GetAttribute("href") != null)
            .Select(element => element.GetAttribute("href"))
            .ToList();

            driver.Keyboard.SendKeys(Keys.Escape);

            return userList;
        }
    }
}
