using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace InstagramApp.Engines.LikeHashTagEngine
{
    public class LikeHashTagEngine : IEngine<LikeHashTagModel>
    {
        public void Execute(RemoteWebDriver driver, LikeHashTagModel model)
        {
            driver.Navigate().GoToUrl("https://www.instagram.com/");

            Thread.Sleep(500);

            IList<IWebElement> inputs = driver.FindElements(By.ClassName("_9x5sw"));
            inputs.FirstOrDefault().SendKeys(model.HashTag);

            Thread.Sleep(1500);

            IList<IWebElement> hashLinks = driver.FindElements(By.ClassName("_k2vj6"));
            hashLinks.FirstOrDefault().Click();

            Thread.Sleep(1500);
            IList<IWebElement> images = driver.FindElements(By.ClassName("_8mlbc"));

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
                    likeButtons.FirstOrDefault().Click();
                }

                Thread.Sleep(500);

                driver.Keyboard.SendKeys(Keys.Escape);
            }
        }
    }
}
