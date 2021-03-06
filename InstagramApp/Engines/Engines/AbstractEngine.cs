﻿using System;
using System.Linq;
using System.Threading;
using Engines.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines
{
    public abstract class AbstractEngine<TModel, TResult> : IEngine<TModel, TResult>
        where TResult : new()
    {
        protected abstract TResult ExecuteEngine(RemoteWebDriver driver, TModel model);

        public TResult Execute(RemoteWebDriver driver, TModel model)
        {
            TResult result;

            try
            {
                result = ExecuteEngine(driver, model);
            }
            catch (CaptchaException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                // todo: Log it
                result = new TResult();
            }

            return result;
        }

        protected bool NavigateToUrl(RemoteWebDriver driver, string url = "https://www.instagram.com/")
        {
            driver.Navigate().GoToUrl(url);

            Thread.Sleep(800);

            var breakButtonExists = driver
                .FindElements(By.TagName("h2"))
                .Any(element => element.Text.Contains("недоступна"));

            if (breakButtonExists)
            {
                return false;
            }

            var captchButtonExists = driver
                .FindElements(By.TagName("h2"))
                .Any(element => element.Text.Contains("Подтвердите"));

            if (captchButtonExists)
            {
                throw new CaptchaException();
            }

            return true;
        }

        protected TResult GetDefaultResult()
        {
            return new TResult();
        }
    }
}
