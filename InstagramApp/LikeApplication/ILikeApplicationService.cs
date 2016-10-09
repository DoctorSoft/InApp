using System.Collections.Generic;
using OpenQA.Selenium.Remote;

namespace LikeApplication
{
    public interface ILikeApplicationService
    {
        List<string> GetProxyList(RemoteWebDriver driver);

        List<string> CheckProxyList(List<string> proxyList);
    }
}
