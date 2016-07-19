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
            buttons.FirstOrDefault(element => element.Text == "Войти").Click();

            Thread.Sleep(2000);

            IList<IWebElement> inputs = driver.FindElements(By.ClassName("_9x5sw"));
            inputs.FirstOrDefault().SendKeys("#Grodno");

            Thread.Sleep(3000);

            IList<IWebElement> hashLinks = driver.FindElements(By.ClassName("_k2vj6"));
            hashLinks.FirstOrDefault().Click();

            Thread.Sleep(3000);
            IList<IWebElement> images = driver.FindElements(By.ClassName("_8mlbc"));

            foreach (var image in images)
            {
                Thread.Sleep(500);
                image.Click();

                Thread.Sleep(500);

                IList<IWebElement> likeSpans = driver.FindElements(By.ClassName("_1tv0k"));
                var text = likeSpans.FirstOrDefault().Text;

                Thread.Sleep(500);

                if (text == "Нравится")
                {
                    IList<IWebElement> likeButtons = driver.FindElements(By.ClassName("_ebwb5"));
                    likeButtons.FirstOrDefault().Click();
                }
                else
                {
                    driver.Keyboard.SendKeys(Keys.Escape);
                    break;
                }

                Thread.Sleep(500);

                driver.Keyboard.SendKeys(Keys.Escape);
            }
        }
    }
}
