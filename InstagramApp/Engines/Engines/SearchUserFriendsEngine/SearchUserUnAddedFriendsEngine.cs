using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Engines.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.SearchUserFriendsEngine
{
    public class SearchUserUnAddedFriendsEngine : AbstractEngine<SearchUserUnAddedFriendsModel, List<string>>
    {
        protected override List<string> ExecuteEngine(RemoteWebDriver driver, SearchUserUnAddedFriendsModel model)
        {
            if (!base.NavigateToUrl(driver, model.UserLink))
            {
                return GetDefaultResult();
            } Thread.Sleep(500);

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

            var followersButton = driver
            .FindElements(By.ClassName("_s53mj"))
            .Where(element =>
            {
                if (element.GetAttribute("href") != null)
                {
                    return element.GetAttribute("href").ToLower().Contains("following");
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

            var count = model.Count;
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

            return userList;
        }
    }
}
