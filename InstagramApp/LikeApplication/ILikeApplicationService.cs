using System.Collections.Generic;
using DataBase.Contexts.LikeApplication;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace LikeApplication
{
    public interface ILikeApplicationService
    {
        List<long> GetActiveAccountIds(LikeApplicationContext context);

        void LikeMediaList(RemoteWebDriver driver, LikeApplicationContext context, long accountId);

        List<string> GetProxyList(RemoteWebDriver driver);

        List<string> CheckProxyList(List<string> proxyList);
    }
}
