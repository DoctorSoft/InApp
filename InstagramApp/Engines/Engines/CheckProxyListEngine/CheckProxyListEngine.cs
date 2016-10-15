using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.CheckProxyListEngine
{
    public class CheckProxyListEngine : AbstractEngine<CheckProxyListModel, List<CheckProxyListAnswerModel>>
    {
        protected override List<CheckProxyListAnswerModel> ExecuteEngine(RemoteWebDriver driver, CheckProxyListModel model)
        {
            var listOfWorkingProxies = new List<CheckProxyListAnswerModel>();
            const string classPageElement = "ip";

            foreach (var currentProxy in model.ProxyList)
            {
                var chromeOptions = new ChromeOptions();
                var chromeProxy = new Proxy
                {
                    SslProxy = currentProxy.Ip + ":" + currentProxy.Port
                };
                chromeOptions.Proxy = chromeProxy;

                var testDriver = new ChromeDriver(chromeOptions);

                try
                {
                    var startTime = DateTime.Now;
                    testDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(model.PageLoadTime));
                    testDriver.Navigate().GoToUrl("https://2ip.ru/");
                    try
                    {
                        if (testDriver.Title.Contains("недоступен"))
                        {
                            testDriver.Close(); 
                            continue;
                        }

                        var loadTime = DateTime.Now - startTime;

                        var pageElement = driver.FindElement(By.ClassName(classPageElement));
                        if (pageElement != null && pageElement.Displayed)
                        {
                            listOfWorkingProxies.Add(
                                new CheckProxyListAnswerModel
                                {
                                    Ip = currentProxy.Ip,
                                    Port = currentProxy.Port,
                                    Speed = loadTime.Minutes * 60 + loadTime.Seconds
                                });
                        }
                        testDriver.Close();
                    }
                    catch (Exception)
                    {
                        testDriver.Close();
                    }
                }
                catch (Exception)
                {
                    testDriver.Close();
                }
            }

            return listOfWorkingProxies;
        }
    }
}
