using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.AddCommentEngine
{
    public class AddCommentEngine : AbstractEngine<AddCommentModel, VoidResult>
    {
        protected override VoidResult ExecuteEngine(RemoteWebDriver driver, AddCommentModel model)
        {
            driver.Navigate().GoToUrl(model.Link);

            Thread.Sleep(500);

            IWebElement textBox = driver.FindElements(By.ClassName("_soakw")).FirstOrDefault();
            if (textBox != null)
            {
                textBox.Clear();
                textBox.SendKeys(model.CommentText);
                textBox.SendKeys(Keys.Enter);
            }

            return new VoidResult();
        }
    }
}
