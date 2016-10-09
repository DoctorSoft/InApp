using System.Collections.Generic;
using OpenQA.Selenium;

namespace SearchProxy
{
    public interface IProxyService
    {
        List<string> GetProxyList(IWebDriver driver);
    }
}
