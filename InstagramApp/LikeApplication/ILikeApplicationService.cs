using System.Collections.Generic;
using OpenQA.Selenium;

namespace LikeApplication
{
    public interface ILikeApplicationService
    {
        List<string> GetProxyList(IWebDriver driver);
    }
}
