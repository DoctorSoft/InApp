using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.GetProxyListEngine
{
    public class GetProxyListEngine : AbstractEngine<GetProxyListModel, List<string>>
    {
        protected override List<string> ExecuteEngine(RemoteWebDriver driver, GetProxyListModel model)
        {
            driver.Navigate().GoToUrl("http://hideme.ru/proxy-list/?type=s&anon=1#list");

            Thread.Sleep(3000);

            var tableRows = driver.FindElements(By.CssSelector(".proxy__t tbody tr"));
            var proxyList =
                tableRows.Select(row => row.Text)
                    .Select(
                        proxyString =>
                            proxyString.Remove(proxyString.IndexOf("\r\n", System.StringComparison.Ordinal))
                                .Replace(" ", ":"))
                    .ToList();

            return proxyList;
        }
    }
}
