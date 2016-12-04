using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Engines.Engines.CheckProxyListEngine;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.GetProxyListEngine
{
    public class GetProxyListEngine : AbstractEngine<GetProxyListModel, List<CheckProxyListAnswerModel>>
    {
        protected override List<CheckProxyListAnswerModel> ExecuteEngine(RemoteWebDriver driver, GetProxyListModel model)
        {
            driver.Navigate().GoToUrl("http://hideme.ru/proxy-list/?type=s&anon=1#list");

            Thread.Sleep(3000);

            var tableRows = driver.FindElements(By.CssSelector(".proxy__t tbody tr"));
            var proxyList =
                tableRows.Select(row => row.Text)
                    .Select(
                        proxyString => new CheckProxyListAnswerModel()
                        {
                            Ip = proxyString.Remove(proxyString.IndexOf("\r\n", System.StringComparison.Ordinal))
                                .Split(Convert.ToChar(" ")).FirstOrDefault(),
                            Port =proxyString.Remove(proxyString.IndexOf("\r\n", System.StringComparison.Ordinal))
                                .Split(Convert.ToChar(" ")).LastOrDefault() 
                        }).ToList();

            return proxyList;
        }
    }
}
