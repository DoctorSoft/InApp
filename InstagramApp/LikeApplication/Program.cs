using OpenQA.Selenium.Chrome;

namespace LikeApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new ChromeDriver();

            var likeApplicationService = new LikeApplicationService();

            var proxyList = likeApplicationService.GetProxyList(driver);
        }
    }
}
