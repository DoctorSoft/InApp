using System;
using DataBase.Contexts.LikeApplication;
using DataBase.QueriesAndCommands.Commands.Proxy;
using DataBase.QueriesAndCommands.Queries.Proxy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LikeApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new LikeApplicationContext())
            {
                var driver = new ChromeDriver();

                var likeApplicationService = new LikeApplicationService();

                likeApplicationService.GetProxyList(driver, context);

                driver.Close();
                
                var accounts = likeApplicationService.GetActiveAccountIds(context);

                foreach (var account in accounts)
                {
                    var proxy = new GetRandomProxyQueryHandler(context).Handle(new GetRandomProxyQuery());
                    var proxyConfigs = new Proxy
                    {
                        SslProxy = proxy.IpAddress + ":" + proxy.Port
                    };
                    var chromeOptions = new ChromeOptions { Proxy = proxyConfigs };
                    var newDriver = new ChromeDriver(chromeOptions);

                    likeApplicationService.LikeMediaList(newDriver, context, account);
                    try
                    {
                        newDriver.Close();
                    }
                    catch (Exception)
                    {
                        
                    }
                    /*new RemoveProxiesByIdCommandHandler(context).Handle(new RemoveProxiesByIdCommand
                    {
                        IpAddress = proxy.IpAddress
                    });*/
                }
            }
        }
    }
}
