using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.VerifyLikeAccountEngine
{
    public class VerifyLikeAccountEngine: AbstractEngine<VerifyLikeAccountModel, VoidResult>
    {
        protected override VoidResult ExecuteEngine(RemoteWebDriver driver, VerifyLikeAccountModel model)
        {
            var count = 5;

            driver.Navigate().GoToUrl("https://temp-mail.ru");
            var refreshButton = driver.FindElement(By.Id("click-to-refresh"));

            Thread.Sleep(3000);

            refreshButton.Click();

            var mail = driver.FindElements(By.ClassName("title-subject")).FirstOrDefault(m=>m.Text.Contains("Insta"));
            while (mail == null && count != 0)
            {
                Thread.Sleep(3000);

                refreshButton.Click();
                mail = driver.FindElements(By.ClassName("title-subject")).FirstOrDefault(m => m.Text.Contains("Insta"));
                count--;
            }
            if (mail != null) 

            Thread.Sleep(2000);

            var verifyButton = driver.FindElements(By.TagName("a")).FirstOrDefault(m => m.Text.Contains("Подтвердите ваш эл. адрес"));
            if (verifyButton != null)
                verifyButton.Click();

            return new VoidResult();
        }
    }
}
