using System;
using System.Data.Entity.Core.Metadata.Edm;
using System.Threading;
using DataBase.Contexts.LikeApplication;
using DataBase.QueriesAndCommands.Commands.Proxy;
using DataBase.QueriesAndCommands.Queries.Proxy;
using Engines.Engines.GetFioForRegistrationEngine;
using Engines.Engines.GetTempEmailEngine;
using Engines.Engines.RegistrationLikeAccountEngine;
using Engines.Engines.VerifyLikeAccountEngine;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace LikeApplicationCreateAccounts
{
    public class LikeApplicationCreateAccountsService
    {
        private bool _workedProxy = true;
        public void RegistrationAccount(RemoteWebDriver driver, LikeApplicationContext context, int numberAccounts)
        {
            var usersFioList = new GetFioForRegistrationEngine().Execute(driver, new GetFioForRegistrationModel()
            {
                Count = numberAccounts
            }).UsersFioList;

            var proxy = new GetFastProxyQueryHandler(context).Handle(new GetFastProxyQuery());
            var proxyDriver = GetNewProxyDriver(context, proxy);
            foreach (var name in usersFioList)
            {
                try
                {
                    if (!_workedProxy)
                    {
                        proxy = new GetFastProxyQueryHandler(context).Handle(new GetFastProxyQuery());
                        proxyDriver = GetNewProxyDriver(context, proxy);
                        _workedProxy = true;
                    }

                    var rnd = new Random();

                    var tempEmail = new GetTempEmailEngine().Execute(driver, new GetTempEmailModel()).Email;
                    var nickName = tempEmail.Substring(0, tempEmail.IndexOf("@", StringComparison.Ordinal)) + rnd.Next(10, 99);
                    var password = "123" + nickName + "SymbolS";

                    var status = new RegistrationLikeAccountEngine().Execute(proxyDriver, new RegistrationLikeAccountModel()
                    {
                        Email = tempEmail,
                        Name = name,
                        NickName = nickName,
                        Password = password
                    });

                    if (!status)
                    {
                        _workedProxy = false;
                        proxyDriver.Close();
                        new RemoveProxiesByIdCommandHandler(context).Handle(new RemoveProxiesByIdCommand()
                        {
                            IpAddress = proxy.IpAddress
                        });
                        continue;
                    }
                    new VerifyLikeAccountEngine().Execute(driver, new VerifyLikeAccountModel());
                    new SaveLikeAccountCommandHandler(context).Handle(new SaveLikeAccountCommand
                    {
                        Email = tempEmail,
                        Password = password,
                        Name = nickName,
                        Link = "https://www.instagram.com/" + nickName + "/"
                    });
                }
                catch (Exception)
                {
                }
            }
        }

        private RemoteWebDriver GetNewProxyDriver(LikeApplicationContext context, ProxyModel proxy)
        {
            var proxyConfigs = new Proxy
            {
                SslProxy = proxy.IpAddress + ":" + proxy.Port
            };

            var chromeOptions = new ChromeOptions
            {
                Proxy = proxyConfigs
            };

            var proxyDriver = new ChromeDriver(chromeOptions);
            proxyDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30));

            return proxyDriver;
        }
    }
}
