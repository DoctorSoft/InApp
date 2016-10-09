using System.Collections.Generic;
using DataBase.Contexts.LikeApplication;
using DataBase.QueriesAndCommands.Queries.LikeApplication;
using Engines.Engines.LikeMediaEngine;
using Engines.Engines.RegistrationEngine;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace LikeApplication
{
    public class LikeApplicationService : ILikeApplicationService
    {
        public List<string> GetProxyList(IWebDriver driver)
        {
            throw new System.NotImplementedException();
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
            }
        }
    }
}
