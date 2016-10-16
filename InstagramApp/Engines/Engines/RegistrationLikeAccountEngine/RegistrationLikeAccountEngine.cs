using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.RegistrationLikeAccountEngine
{
    public class RegistrationLikeAccountEngine: AbstractEngine<RegistrationLikeAccountModel, bool>
    {
        protected override bool ExecuteEngine(RemoteWebDriver driver, RegistrationLikeAccountModel model)
        {
            NavigateToUrl(driver);

            try
            {
                var email = driver.FindElement(By.Name("email"));
                var name = driver.FindElement(By.Name("fullName"));
                var nickName = driver.FindElement(By.Name("username"));
                var password = driver.FindElement(By.Name("password"));
                var button = driver.FindElements(By.CssSelector("._aj7mu._taytv._ki5uo._o0442")).FirstOrDefault(m => m.Text.Contains("Регистрация"));

                email.SendKeys(model.Email);
                Thread.Sleep(3000);
                name.SendKeys(model.Name);
                Thread.Sleep(3000);
                nickName.SendKeys(model.NickName);
                Thread.Sleep(3000);
                password.SendKeys(model.Password);
                Thread.Sleep(3000);

                if (button != null) 
                    button.Click();

                Thread.Sleep(3000);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
