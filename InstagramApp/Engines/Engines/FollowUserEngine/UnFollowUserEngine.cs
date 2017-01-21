﻿using System.Linq;
using System.Threading;
using Engines.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.FollowUserEngine
{
    public class UnFollowUserEngine : AbstractEngine<UnFollowUserModel, bool>
    {
        protected override bool ExecuteEngine(RemoteWebDriver driver, UnFollowUserModel model)
        {
            driver.Navigate().GoToUrl(model.UserLink);

            Thread.Sleep(500);

            var breakButtonExists = driver
                .FindElements(By.TagName("h2"))
                .Any(element => element.Text.Contains("недоступна"));

            if (breakButtonExists)
            {
                return GetDefaultResult();
            }

            var captchButtonExists = driver
                .FindElements(By.TagName("h2"))
                .Any(element => element.Text.Contains("Подтвердите"));

            if (captchButtonExists)
            {
                throw new CaptchaException();
            }

            var followButton = driver
                .FindElements(By.ClassName("_ah57t"))
                .First();

            Thread.Sleep(200);

            if (!followButton.Text.Contains("Подписаться"))
            {
                followButton.Click();
            }

            Thread.Sleep(400);

            driver.Navigate().GoToUrl(model.UserLink);

            Thread.Sleep(500);

            followButton = driver
                .FindElements(By.ClassName("_ah57t"))
                .First();

            if (!followButton.Text.Contains("Подписаться"))
            {
                return false;
            }

            return true;
        }
    }
}
