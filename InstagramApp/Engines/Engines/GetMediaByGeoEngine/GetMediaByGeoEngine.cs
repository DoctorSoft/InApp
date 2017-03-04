using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.GetMediaByGeoEngine
{
    public class GetMediaByGeoEngine : AbstractEngine<GetMediaByGeoModel, List<string>>
    {
        protected override List<string> ExecuteEngine(RemoteWebDriver driver, GetMediaByGeoModel model)
        {
            var geoUrl = GeoLinks.Links[model.Geo];
            driver.Navigate().GoToUrl(geoUrl);

            Thread.Sleep(1500);

            int countShownImages = GetCountShownImages(driver);

            Thread.Sleep(500);

            var breakFactor = 0;
            do
            {
                ClickToDownloadMore(driver);
                countShownImages = GetCountShownImages(driver);

                if (++breakFactor > model.CountMedia)
                {
                    break;
                }
            } while (countShownImages < model.CountMedia);

            var images = GetLinksToImages(driver, model.CountMedia);

            return images.Select(image => image.GetAttribute("href")).ToList();
        }

        private void ClickToDownloadMore(RemoteWebDriver driver)
        {
            IList<IWebElement> links = driver.FindElements(By.TagName("a"));
            bool firstClick = links.Any(element => element.GetAttribute("Class") == "_oidfu") ? true : false; ;

            if (firstClick)
            {
                IWebElement buttonDownloadMore = links.First(element => element.GetAttribute("Class") == "_oidfu");

                buttonDownloadMore.Click();

                Thread.Sleep(1000);
            }
            else
            {
                var js = (IJavaScriptExecutor)driver;
                js.ExecuteScript(string.Format("window.scrollBy({0}, {1})", 3000, 3000), "");

                Thread.Sleep(1000);
            }
        }

        private int GetCountShownImages(RemoteWebDriver driver)
        {
            var countImages = driver
            .FindElements(By.ClassName("_8mlbc")).Count;

            return countImages;
        }

        private List<IWebElement> GetLinksToImages(RemoteWebDriver driver, int countImages)
        {
            var linksToIgnore = driver.FindElement(By.ClassName("_5kftd")).FindElements(By.ClassName("_8mlbc"));

            var linksToImages = driver
            .FindElements(By.ClassName("_8mlbc")).Except(linksToIgnore).Take(countImages);

            return linksToImages.ToList();
        }
    }
}
