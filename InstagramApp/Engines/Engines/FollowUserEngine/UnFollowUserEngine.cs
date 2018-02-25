﻿using System.Linq;
using System.Threading;
using Engines.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using RestSharp.Extensions;

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
                .FindElements(By.CssSelector("._qv64e._t78yp._r9b8f._njrw0"))
                .First();

            Thread.Sleep(200);

            var words = new[] { "подписаться", "follow" };
            var btnText = followButton.Text.ToLower();
            if (words.All(s => s != btnText))
            {
                followButton.Click();
            }

            Thread.Sleep(400);

            driver.Navigate().GoToUrl(model.UserLink);

            Thread.Sleep(500);
            
            followButton = driver
                .FindElements(By.CssSelector("._qv64e._gexxb._r9b8f._njrw0"))
                .First();

            btnText = followButton.Text.ToLower();
            if (words.All(s => s != btnText))
            {
                return false;
            }

            return true;
        }
    }
}
