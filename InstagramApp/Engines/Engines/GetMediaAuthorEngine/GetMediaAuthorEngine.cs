using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.GetMediaAuthorEngine
{
    public class GetMediaAuthorEngine : AbstractEngine<GetMediaAuthorModel, GetMediaAuthorEngineResponse>
    {
        protected override GetMediaAuthorEngineResponse ExecuteEngine(RemoteWebDriver driver, GetMediaAuthorModel model)
        {
            driver.Navigate().GoToUrl(model.Link);

            Thread.Sleep(800);

            var userLinkTag = driver
                .FindElements(By.ClassName("_4zhc5"))
                .FirstOrDefault();

            if (userLinkTag == null)
            {
                return GetDefaultResult();
            }

            var userLink = userLinkTag.GetAttribute("href");

            return new GetMediaAuthorEngineResponse
            {
                UserLink = userLink
            };
        }
    }
}
