using System.Collections.Generic;
using DataBase.Contexts.LikeApplication;
using DataBase.QueriesAndCommands.Commands.LikeApplication;
using DataBase.QueriesAndCommands.Commands.Proxy;
using DataBase.QueriesAndCommands.Queries.LikeApplication;
using Engines.Engines.LikeMediaEngine;
using Engines.Engines.RegistrationEngine;
using OpenQA.Selenium;
using Engines.Engines.CheckProxyListEngine;
using Engines.Engines.GetProxyListEngine;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace LikeApplication
{
    public class LikeApplicationService : ILikeApplicationService
    {
        public List<string> GetProxyList(RemoteWebDriver driver, LikeApplicationContext context)
        {
            var proxyList = CheckProxyList(new GetProxyListEngine().Execute(driver, new GetProxyListModel()));

            new SaveProxyListCommandHandler(context).Handle(new SaveProxyListCommand
            {
                Proxies = proxyList
            });

            return proxyList;
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

                if (statusProxy)
                {
                    listSuccesfulProxy.Add(currentProxy);
                }
            }

            return listSuccesfulProxy;
        }

        public List<long> GetActiveAccountIds(LikeApplicationContext context)
        {
            var accountIds = new GetActiveLikeAccountIdListQueryHandler(context).Handle(new GetActiveLikeAccountIdListQuery());

            return accountIds;
        }

        public void LikeMediaList(RemoteWebDriver driver, LikeApplicationContext context, long accountId)
        {
            var data = new GetLikeAccountDataQueryHandler(context).Handle(new GetLikeAccountDataQuery
            {
                Id = accountId
            });

            new RegistrationEngine().Execute(driver, new RegistrationModel
            {
                Password = data.Password,
                UserName = data.Login
            });

            foreach (var media in data.MediasToLike)
            {
                new LikeMediaEngine().Execute(driver, new LikeMediaModel
                {
                    Link = media
                });
                new RemoveAccountToLikeMediaCommandHandler(context).Handle(new RemoveAccountToLikeMediaCommand
                {
                    LikeAccountId = accountId,
                    LikeMediaLink = media
                });
            }
        }
    }
}
