using Engines.Engines.GetFioForRegistrationEngine;
using Engines.Engines.GetTempEmailEngine;
using OpenQA.Selenium.Remote;

namespace LikeApplicationCreateAccounts
{
    public class LikeApplicationCreateAccountsService
    {
        public GetFioForRegistrationResponseModel GetFioForRegistration(RemoteWebDriver driver)
        {
            return new GetFioForRegistrationEngine().Execute(driver, new GetFioForRegistrationModel()
            {
                Count =  50
            });
        }

        public string GetTempEmail(RemoteWebDriver driver)
        {
            return new GetTempEmailEngine().Execute(driver, new GetTempEmailModel()).Email;
        }

        public void  RegistrationAccount(RemoteWebDriver driver)
        {
            var usersFioList = GetFioForRegistration(driver);

        }
    }
}
