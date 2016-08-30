using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.LikeTheLinkEngine
{
    public class LikeTheLinkEngine: AbstractEngine<LikeTheLinkModel, VoidResult>
    {
        protected override VoidResult ExecuteEngine(RemoteWebDriver driver, LikeTheLinkModel model)
        {
            driver.Navigate().GoToUrl(model.Link);

            Thread.Sleep(500);

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
            return new VoidResult();
        }
    }
}
