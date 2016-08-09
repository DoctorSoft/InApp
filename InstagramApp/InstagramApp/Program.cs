using OpenQA.Selenium.Chrome;

namespace InstagramApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var driver = new ChromeDriver())
            {
                var service = new InstagramService();

                service.ApproveUsers(driver);
            }
        }
    }
}
