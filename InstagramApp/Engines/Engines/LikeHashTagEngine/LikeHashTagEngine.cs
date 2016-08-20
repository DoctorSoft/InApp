using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.LikeHashTagEngine
{
    public class LikeHashTagEngine : IEngine<LikeHashTagModel, List<string>>
    {
        public List<string> Execute(RemoteWebDriver driver, LikeHashTagModel model)
        {
            var linksList = new List<string>();
            int countShownImages = GetCountShownImages(driver);

            driver.Navigate().GoToUrl("https://www.instagram.com/");

            Thread.Sleep(500);

            IList<IWebElement> inputs = driver.FindElements(By.ClassName("_9x5sw"));
            inputs.FirstOrDefault().SendKeys(model.HashTag);

            Thread.Sleep(1500);

            IList<IWebElement> hashLinks = driver.FindElements(By.ClassName("_k2vj6"));
            hashLinks.FirstOrDefault().Click();

            Thread.Sleep(1500);

            while (countShownImages < model.CountMedia)
            {
                ClickToDownloadMore(driver);
                countShownImages = GetCountShownImages(driver);
            }

            var images = GetLinksToImages(driver, model.CountMedia);

            foreach (var image in images)
            {
                Thread.Sleep(500);
                image.Click();

                Thread.Sleep(500);

                string text;

                try
                {
                    IList<IWebElement> likeSpans = driver.FindElements(By.ClassName("_1tv0k"));
                    text = likeSpans.FirstOrDefault().Text;
                }
                catch
                {
                    Thread.Sleep(500);
                    IList<IWebElement> likeSpans = driver.FindElements(By.ClassName("_1tv0k"));
                    text = likeSpans.FirstOrDefault().Text;
                }

                Thread.Sleep(500);

                if (text == "Нравится")
                {
                    IList<IWebElement> likeButtons = driver.FindElements(By.ClassName("_ebwb5"));
                    linksList.Add(image.GetAttribute("href"));
                    likeButtons.FirstOrDefault().Click();
                }

                Thread.Sleep(500);

                driver.Keyboard.SendKeys(Keys.Escape);
            }

            return linksList;
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
            };
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
