using System.Collections.Generic;
using Engines.Engines.CheckProxyListEngine;
using Engines.Engines.GetProxyListEngine;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace LikeApplication
{
    public class LikeApplicationService : ILikeApplicationService
    {
        public List<string> GetProxyList(RemoteWebDriver driver)
        {
            return CheckProxyList(new GetProxyListEngine().Execute(driver, new GetProxyListModel()));
        }

        public List<string> CheckProxyList(List<string> proxyList)
        {
            var listSuccesfulProxy = new List<string>();

            foreach (var currentProxy in proxyList)
            {
                var chromeOptions = new ChromeOptions();
                var chromeProxy = new Proxy
                {
                    SslProxy = currentProxy
                };
                chromeOptions.Proxy = chromeProxy;

                var testDriver = new ChromeDriver(chromeOptions);

                var statusProxy = new CheckProxyListEngine().Execute(testDriver, new CheckProxyListModel
                {
                    PageLoadTime = 5
                });

                testDriver.Close();

                if (statusProxy) listSuccesfulProxy.Add(currentProxy);
            }

            return listSuccesfulProxy;
        }
    }
}
