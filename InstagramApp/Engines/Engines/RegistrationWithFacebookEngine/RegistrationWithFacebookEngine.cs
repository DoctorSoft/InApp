using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.RegistrationWithFacebookEngine
{
    public class RegistrationWithFacebookEngine: AbstractEngine<RegistrationWithFacebookModel, VoidResult>
    {
        protected override VoidResult ExecuteEngine(RemoteWebDriver driver, RegistrationWithFacebookModel model)
        {
            if (!base.NavigateToUrl(driver))
            {
                return GetDefaultResult();
            }

            Thread.Sleep(1000);

            var logIinWithFacebookButton = driver.FindElement(By.CssSelector("._aj7mu._taytv._ki5uo._o0442"));
            if (logIinWithFacebookButton!=null)
            {
                logIinWithFacebookButton.Click();
            }

            Thread.Sleep(2000);

            IList<IWebElement> userNameInputs = driver.FindElements(By.Name("email"));
            userNameInputs.FirstOrDefault().SendKeys(model.UserName);

            Thread.Sleep(1000);

            IList<IWebElement> passwordInuts = driver.FindElements(By.Name("pass"));
            passwordInuts.FirstOrDefault().SendKeys(model.Password);

            Thread.Sleep(1000);

            //
//
//
//            var registrtionData = links.FirstOrDefault(element => element.Text == "Вход");
//            if (registrtionData == null)
//            {
//                return new VoidResult();
//            }
//            registrtionData.Click();
//
//            Thread.Sleep(1000);
//
//
//
//            Thread.Sleep(1000);
//
//            IList<IWebElement> buttons = driver.FindElements(By.TagName("button"));
//            buttons.FirstOrDefault(element => element.Text == "Войти").Click();
//
//            Thread.Sleep(10000);
//
//            if (!base.NavigateToUrl(driver))
//            {
//                return GetDefaultResult();
//            }
//
//            Thread.Sleep(1000);

            return new VoidResult();
        }
    }
}
