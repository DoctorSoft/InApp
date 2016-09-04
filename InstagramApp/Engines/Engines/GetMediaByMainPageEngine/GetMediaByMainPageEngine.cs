using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.GetMediaByMainPageEngine
{
    public class GetMediaByMainPageEngine: AbstractEngine<GetMediaByMainPageModel, List<string>>
    {
        protected override List<string> ExecuteEngine(RemoteWebDriver driver, GetMediaByMainPageModel model)
        {

            if (!base.NavigateToUrl(driver))
            {
                return GetDefaultResult();
            }

            Thread.Sleep(1500);

            var countShownImages = GetCountShownImages(driver);

            var breakFactor = 0;
            while (countShownImages < model.CountMedia)
            {
                ScrollPage(driver);

                if (++breakFactor > model.CountMedia)
                {
                    break;
                }
            }
            var images = GetLinksToImages(driver, model.CountMedia);
            return images.Select(image => image.GetAttribute("href")).ToList();

        }
        private IEnumerable<IWebElement> GetLinksToImages(RemoteWebDriver driver, int countImages)
        {
            var linksToImages = driver
            .FindElements(By.ClassName("_ljyfo")).Take(countImages);

            return linksToImages;
        }

        private int GetCountShownImages(RemoteWebDriver driver)
        {
            var countImages = driver
            .FindElements(By.ClassName("_8ab8k")).Count;

            return countImages;
        }

        private void ScrollPage(RemoteWebDriver driver)
        {
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(string.Format("window.scrollBy({0}, {1})", 3000, 3000), "");

            Thread.Sleep(1000);
        }
    }
}
