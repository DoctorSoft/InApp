using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.CheckProxyListEngine
{
    public class CheckProxyListEngine : AbstractEngine<CheckProxyListModel, bool>
    {
        protected override bool ExecuteEngine(RemoteWebDriver driver, CheckProxyListModel model)
        {
            driver.Navigate().GoToUrl("https://2ip.ru/");
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            //wait.Until(e => e.FindElement(By.Id("lst-ib")));

            Thread.Sleep(TimeSpan.FromSeconds(model.PageLoadTime));
            var pageElement = driver.FindElement(By.Id("d_clip_button"));
            return pageElement != null && pageElement.Displayed;
        }
    }
}
