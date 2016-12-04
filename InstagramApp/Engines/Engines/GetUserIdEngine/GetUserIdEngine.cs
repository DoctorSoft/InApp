using System.Linq;
using System.Text.RegularExpressions;
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

            NavigateToUrl(driver, model.UserLink);

            var text = driver.PageSource;

            var regex = new Regex("owner[^.]*{[^}]*");

            var idMatchData = regex.Match(text).Value;

            regex = new Regex("\\d[^\\D]*");

            var id = regex.Match(idMatchData).Value;

            return new UserInfo
            {
                Id = id,
                UserName = userName
            };
        }
    }
}
