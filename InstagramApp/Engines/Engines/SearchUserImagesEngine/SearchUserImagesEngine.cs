using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.SearchUserImagesEngine
{
    public class SearchUserImagesEngine : IEngine<SearchUserImagesModel, List<string>>
    {
        public List<string> Execute(RemoteWebDriver driver, SearchUserImagesModel model)
        {
            driver.Navigate().GoToUrl(model.UserPageLink);

            int countShownImages = GetCountShownImages(driver);

            while (countShownImages < model.CountImages)
            {
                ClickToDownloadMore(driver);
                countShownImages = GetCountShownImages(driver);
            }

            var list = GetLinksToImages(driver, model.CountImages);

            return list.Select(element => element.GetAttribute("href")).ToList();
        }

        private void ClickToDownloadMore(RemoteWebDriver driver)
        {

            IList<IWebElement> links = driver.FindElements(By.TagName("a"));
            bool firstClick = links.Any(element => element.GetAttribute("Class") == "_oidfu") ? true : false;;

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

        private IEnumerable<IWebElement> GetLinksToImages(RemoteWebDriver driver, int countImages)
        {
            var linksToImages = driver
            .FindElements(By.ClassName("_8mlbc")).Take(countImages);

            return linksToImages;
        }

        private int GetCountShownImages(RemoteWebDriver driver)
        {
            var countImages = driver
            .FindElements(By.ClassName("_8mlbc")).Count;

            return countImages;
        }
    }
}
