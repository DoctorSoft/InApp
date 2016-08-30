using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.RegistrationEngine
{
    public class RegistrationEngine : AbstractEngine<RegistrationModel, VoidResult>
    {
        protected override VoidResult ExecuteEngine(RemoteWebDriver driver, RegistrationModel model)
        {
            driver.Navigate().GoToUrl("https://www.instagram.com/");

            IList<IWebElement> links = driver.FindElements(By.TagName("a"));

            var registrtionData = links.FirstOrDefault(element => element.Text == "Вход");
            if (registrtionData == null)
            {
                return new VoidResult();
            }
            registrtionData.Click();

            Thread.Sleep(500);

            IList<IWebElement> userNameInputs = driver.FindElements(By.Name("username"));
            userNameInputs.FirstOrDefault().SendKeys(model.UserName);

            Thread.Sleep(500);

            IList<IWebElement> passwordInuts = driver.FindElements(By.Name("password"));
            passwordInuts.FirstOrDefault().SendKeys(model.Password);

            Thread.Sleep(500);

            IList<IWebElement> buttons = driver.FindElements(By.TagName("button"));
            buttons.FirstOrDefault(element => element.Text == "Войти").Click();

            Thread.Sleep(2000);

            driver.Navigate().GoToUrl("https://www.instagram.com/");

            Thread.Sleep(1000);

            return new VoidResult();
        }
    }
}
