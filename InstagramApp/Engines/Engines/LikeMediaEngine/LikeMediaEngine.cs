using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.LikeMediaEngine
{
    public class LikeMediaEngine : AbstractEngine<LikeMediaModel, LikeMediaEngineResponse>
    {
        protected override LikeMediaEngineResponse ExecuteEngine(RemoteWebDriver driver, LikeMediaModel model)
        {
            if (!base.NavigateToUrl(driver, model.Link))
            {
                return GetDefaultResult();
            }

            string text;

            try
            {
                IList<IWebElement> likeSpans = driver.FindElements(By.ClassName("_soakw"));
                text = likeSpans.FirstOrDefault().Text;
            }
            catch
            {
                Thread.Sleep(500);
                IList<IWebElement> likeSpans = driver.FindElements(By.ClassName("_soakw"));
                text = likeSpans.FirstOrDefault().Text;
            }

            if (text == "Нравится")
            {
                IList<IWebElement> likeButtons = driver.FindElements(By.ClassName("_ebwb5"));
                likeButtons.FirstOrDefault().Click();
            }

            var followButton = driver
                .FindElements(By.ClassName("_aj7mu"))
                .First();

            if (followButton.Text.Contains("Подписаться"))
            {
                var userLinkTag = driver
                    .FindElements(By.ClassName("_4zhc5"))
                    .FirstOrDefault();

                if (userLinkTag == null)
                {
                    return GetDefaultResult();
                }

                var userLink = userLinkTag.GetAttribute("href");

                return new LikeMediaEngineResponse
                {
                    UserLink = userLink
                };
            }

            return GetDefaultResult();
        }
    }
}
