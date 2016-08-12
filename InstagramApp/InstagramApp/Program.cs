using DataBase.Contexts;
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

                using (var context = new MyDevPageContext())
                {
                    service.ApproveUsers(driver, context);
                }
            }
        }
    }
}
