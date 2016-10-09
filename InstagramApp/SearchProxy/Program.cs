using OpenQA.Selenium.Chrome;

namespace SearchProxy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var driver = new ChromeDriver();

            var proxyService = new ProxyService();

            proxyService.GetProxyList(driver);
        }
    }
}
