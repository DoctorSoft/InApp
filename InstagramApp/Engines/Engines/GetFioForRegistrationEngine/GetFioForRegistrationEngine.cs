using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.GetFioForRegistrationEngine
{
    public class GetFioForRegistrationEngine: AbstractEngine<GetFioForRegistrationModel, GetFioForRegistrationResponseModel>
    {
        protected override GetFioForRegistrationResponseModel ExecuteEngine(RemoteWebDriver driver,
            GetFioForRegistrationModel model)
        {
            driver.Navigate().GoToUrl("https://sfztn.com/names-generator");

            Thread.Sleep(2000);
            var list = GetNames(driver, true);

            try
            {
                while (list.Count <= model.Count)
                {
                    var newList = GetNames(driver, false);
                    list.AddRange(newList);
                }
            }
            catch (Exception)
            {
            }

            return new GetFioForRegistrationResponseModel()
            {
                UsersFioList = list
            };
        }

        internal List<string> GetNames(RemoteWebDriver driver, bool firstCall)
        {
            if (!firstCall)
            {
                driver.FindElement(By.Id("fam-sbm")).Click();
            }
            return driver.FindElements(By.CssSelector("#list-passwors li")).Select(m=>m.Text).ToList();
        }
    }
}
