using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.GetUserIdEngine
{
    public class GetUserIdEngine : AbstractEngine<GetUserIdEngineModel, UserInfo>
    {
        protected override UserInfo ExecuteEngine(RemoteWebDriver driver, GetUserIdEngineModel model)
        {
            var userName = model.UserLink;
            if (userName[userName.Length - 1] == '/')
            {
                userName = userName.Remove(userName.Length - 1);
            }
            userName = userName.Split('/').Last();

            var linkToCheckId = "https://smashballoon.com/instagram-feed/find-instagram-user-id/?username=" + userName;

            driver.Navigate().GoToUrl(linkToCheckId);

            Thread.Sleep(1500);

            var elementWithId = driver.FindElementById("show_id");
            var userElements = elementWithId.FindElements(By.ClassName("user"));
            var matchElements = userElements.Where(element => element.Text.ToUpper().Contains(userName.ToUpper()));
            var matchElement = matchElements.FirstOrDefault();
            var id = matchElement.FindElements(By.TagName("b")).Last().Text.Split(' ').Last();

            var result = new UserInfo
            {
                UserName = userName,
                Id = id
            };

            return result;
        }
    }
}
