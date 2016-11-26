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


            var registrtionButton = driver.FindElement(By.Id("loginbutton"));
            if (registrtionButton == null)
            {
                return new VoidResult();
            }
            registrtionButton.Click();

            Thread.Sleep(2000);

            var stepOneButton = driver.FindElement(By.Name("__CONFIRM__"));
            if (stepOneButton == null)
            {
                return new VoidResult();
            }
            stepOneButton.Click();

            Thread.Sleep(2000);

            var stepTwoButton = driver.FindElement(By.Id("checkpointSubmitButton"));
            if (stepTwoButton == null)
            {
                return new VoidResult();
            }
            stepTwoButton.Click();

            Thread.Sleep(2000);

            var stepThreeButton = driver.FindElement(By.Id("checkpointSubmitButton"));
            if (stepThreeButton == null)
            {
                return new VoidResult();
            }
            stepThreeButton.Click();

            Thread.Sleep(2000);

            var stepFourButton = driver.FindElements(By.TagName("a")).FirstOrDefault(element => element.Text == "I can't upload a photo");
            if (stepFourButton == null)
            {
                return new VoidResult();
            }
            stepFourButton.Click();

            Thread.Sleep(2000);

            if (!base.NavigateToUrl(driver))
            {
                return GetDefaultResult();
            }

            Thread.Sleep(1000);

            return new VoidResult();
        }
    }
}
