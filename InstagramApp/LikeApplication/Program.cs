using DataBase.Contexts.LikeApplication;
using OpenQA.Selenium.Chrome;

namespace LikeApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //var driver = new ChromeDriver();

            var likeApplicationService = new LikeApplicationService();

            using (var context = new LikeApplicationContext())
            {
                var accounts = likeApplicationService.GetActiveAccountIds(context);

                foreach (var account in accounts)
                {
                    var newDriver = new ChromeDriver();

                    likeApplicationService.LikeMediaList(newDriver, context, account);

                    newDriver.Close();
                }
            }
        }
    }
}
