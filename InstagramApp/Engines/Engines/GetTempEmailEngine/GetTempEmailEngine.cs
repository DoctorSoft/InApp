using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.GetTempEmailEngine
{
    public class GetTempEmailEngine : AbstractEngine<GetTempEmailModel, GetTempEmailResponseModel>
    {
        protected override GetTempEmailResponseModel ExecuteEngine(RemoteWebDriver driver, GetTempEmailModel model)
        {
            driver.Navigate().GoToUrl("https://temp-mail.ru");

            driver.FindElement(By.Id("click-to-delete")).Click();
            
            Thread.Sleep(500);

            var email = driver.FindElement(By.Id("mail")).GetAttribute("value");
            
            return new GetTempEmailResponseModel()
            {
                Email = email
            };
        }
    }
}
