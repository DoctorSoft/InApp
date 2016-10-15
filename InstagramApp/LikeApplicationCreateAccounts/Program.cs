using OpenQA.Selenium.Chrome;

namespace LikeApplicationCreateAccounts
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new LikeApplicationCreateAccountsService();
            var driver = new ChromeDriver();

            service.GetFioForRegistration(driver);
            var email = service.GetTempEmail(driver);
        }
    }
}
