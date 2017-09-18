using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.LikeFriendsPostsEngine
{
    public class LikeFriendsPostsEngine : AbstractEngine<LikeFriendsPostsModel, VoidResult>
    {
        protected override VoidResult ExecuteEngine(RemoteWebDriver driver, LikeFriendsPostsModel model)
        {
            if (!base.NavigateToUrl(driver))
            {
                return GetDefaultResult();
            }

            var count = 0;

            for (var i = 0; i < 10; i++)
            {
                IList<IWebElement> likes = driver.FindElements(By.CssSelector("._eszkz._l9yih"));
                var realLikes = likes.Where((element, index) => index >= count).ToList();
                count = likes.Count;

                foreach (var like in realLikes)
                {
                    if (like.Text == "Нравится")
                    {
                        Thread.Sleep(500);
                        like.Click();
                    }
                }

                var js = (IJavaScriptExecutor)driver;
                js.ExecuteScript(string.Format("window.scrollBy({0}, {1})", i * 3000, (i + 1) * 3000), "");

                Thread.Sleep(1000);
            }

            return new VoidResult();
        }
    }
}
