using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.WaitingCaptchEngine
{
    public class WaitingCaptchaEngine : AbstractEngine<WaitingCaptchaEngineModel, VoidResult>
    {
        protected override VoidResult ExecuteEngine(RemoteWebDriver driver, WaitingCaptchaEngineModel model)
        {
            bool captchButtonExists;

            do
            {
                Thread.Sleep(TimeSpan.FromMinutes(1));

                driver.Navigate().GoToUrl(model.TestLink);

                Thread.Sleep(500);

                var breakButtonExists = driver
                    .FindElements(By.TagName("h2"))
                    .Any(element => element.Text.Contains("недоступна"));

                if (breakButtonExists)
                {
                    return new VoidResult();
                }

                captchButtonExists = driver
                    .FindElements(By.TagName("h2"))
                    .Any(element => element.Text.Contains("Подтвердите"));
            } 
            while (captchButtonExists);

            return new VoidResult();
        }
    }
}
