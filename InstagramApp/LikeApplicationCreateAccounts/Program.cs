using DataBase.Contexts.LikeApplication;
using OpenQA.Selenium.Chrome;

namespace LikeApplicationCreateAccounts
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new LikeApplicationContext())
            {
                var service = new LikeApplicationCreateAccountsService();

                var driver = new ChromeDriver();

                service.RegistrationAccount(driver, context: context, numberAccounts: 3);
            }
        }
    }
}
