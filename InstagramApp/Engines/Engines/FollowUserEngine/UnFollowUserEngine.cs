using System.Linq;
using System.Threading;
using DataBase.Contexts;
using DataBase.QueriesAndCommands;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.FollowUserEngine
{
    public class UnFollowUserEngine : IEngine<UnFollowUserModel, VoidResult>
    {
        public VoidResult Execute(RemoteWebDriver driver, UnFollowUserModel model)
        {
            driver.Navigate().GoToUrl(model.UserLink);

            var followButton = driver
                .FindElements(By.ClassName("_aj7mu"))
                .First();

            Thread.Sleep(200);

            if (!followButton.Text.Contains("Подписаться"))
            {
                followButton.Click();
            }

            Thread.Sleep(400);

            return new VoidResult();
        }
    }
}
