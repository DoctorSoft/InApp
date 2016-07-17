using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InstagramApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.instagram.com/");

            IList<IWebElement> links = driver.FindElements(By.TagName("a"));
            links.First(element => element.Text == "Вход").Click();

            Thread.Sleep(500);

            IList<IWebElement> userNameInputs = driver.FindElements(By.Name("username"));
            userNameInputs.FirstOrDefault().SendKeys("mydevpage");

            Thread.Sleep(500);

            IList<IWebElement> passwordInuts = driver.FindElements(By.Name("password"));
            passwordInuts.FirstOrDefault().SendKeys("Ntvyjnf123");

            Thread.Sleep(500);

            IList<IWebElement> buttons = driver.FindElements(By.TagName("button"));
            buttons.First(element => element.Text == "Войти").Click();
        }
    }
}
