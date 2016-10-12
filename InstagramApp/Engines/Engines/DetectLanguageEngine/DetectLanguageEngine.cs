using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.DetectLanguageEngine
{
    public class DetectLanguageEngine : AbstractEngine<DetectLanguageEngineModel, LanguageModel>
    {
        protected override LanguageModel ExecuteEngine(RemoteWebDriver driver, DetectLanguageEngineModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Text))
            {
                return null;
            }

            driver.Navigate().GoToUrl("https://translate.google.ru/#auto/ru/");

            Thread.Sleep(1000);
            
            var textArea = driver.FindElementByTagName("textarea");

            textArea.SendKeys(model.Text);

            Thread.Sleep(1000);

            //gt-sl-sugg

            var buttonsDiv = driver.FindElementById("gt-sl-sugg");
            var languageButton = buttonsDiv.FindElements(By.ClassName("jfk-button-checked")).FirstOrDefault();

            var text = languageButton.Text.Split(' ').First();

            return new LanguageModel
            {
                Language = text
            };
        }
    }
}
