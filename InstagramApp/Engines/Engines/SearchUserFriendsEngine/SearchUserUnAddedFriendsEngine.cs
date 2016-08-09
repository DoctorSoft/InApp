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
    public class SearchUserUnAddedFriendsEngine : IEngine<SearchUserUnAddedFriendsModel, List<string>>
    {
        public List<string> Execute(RemoteWebDriver driver, SearchUserUnAddedFriendsModel model)
        {
            driver.Navigate().GoToUrl(model.UserPageLink);

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
                    return element.GetAttribute("href").ToLower().Contains("following");
                }
                return false;
            })
            .Single();

            followersButton.Click();

            Thread.Sleep(1500);

            var window = driver
                .FindElements(By.TagName("li"))
                .First(element => element.GetAttribute("class") == "_cx1ua");

            window.Click();

            Thread.Sleep(500);

            for (var i = 0; i < Math.Min(count, 1000); i++)
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

            var addUserListCommand = new AddUserListCommand
            {
                Users = userList
            };
            new AddUserListCommandHandler(new DataBaseContext()).Handle(addUserListCommand);
        }
    }
}
