using System.Collections.Generic;
using System.Linq;
using DataBase.Contexts.LikeApplication;
using DataBase.QueriesAndCommands.Commands.LikeApplication;
using DataBase.QueriesAndCommands.Commands.Proxy;
using DataBase.QueriesAndCommands.Queries.LikeApplication;
using DataBase.QueriesAndCommands.Queries.Proxy;
using Engines.Engines.LikeMediaEngine;
using Engines.Engines.RegistrationEngine;
using Engines.Engines.CheckProxyListEngine;
using Engines.Engines.GetProxyListEngine;
using OpenQA.Selenium.Remote;

namespace LikeApplication
{
    public class LikeApplicationService
    {
        public void GetProxyList(RemoteWebDriver driver, LikeApplicationContext context)
        {
            var proxyList = GetListOfWorkingProxies(driver, new GetProxyListEngine().Execute(driver, new GetProxyListModel()));
            if (proxyList.Count == 0) return;

            new SaveProxyListCommandHandler(context).Handle(new SaveProxyListCommand
            {
                Proxies = proxyList.Select(inputElement => new ProxyModel()
                {
                    IpAddress = inputElement.Ip,
                    Port = inputElement.Port,
                    Speed = inputElement.Speed
                }).ToList()
            });
        }
        
        public List<CheckProxyListAnswerModel> GetListOfWorkingProxies(RemoteWebDriver driver, List<CheckProxyListAnswerModel> proxyList)
        {
            return new CheckProxyListEngine().Execute(driver, new CheckProxyListModel
            {
                PageLoadTime = 50,
                ProxyList = proxyList
            });
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
