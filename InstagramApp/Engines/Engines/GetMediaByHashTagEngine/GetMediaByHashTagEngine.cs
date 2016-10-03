using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.GetMediaByHashTagEngine
{
    public class GetMediaByHashTagEngine : AbstractEngine<GetMediaByHashTagModel, List<string>>
    {
        protected override List<string> ExecuteEngine(RemoteWebDriver driver, GetMediaByHashTagModel model)
        {
            var hashTagName = model.HashTag.Replace("#", string.Empty);

            if (!base.NavigateToUrl(driver, "https://www.instagram.com/explore/tags/" + hashTagName))
            {
                return GetDefaultResult();
            }

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

        private IEnumerable<IWebElement> GetLinksToImages(RemoteWebDriver driver, int countImages)
        {
            var linksToImages = driver
            .FindElements(By.ClassName("_8mlbc")).Take(countImages);

            return linksToImages;
        }

    }
}
