using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Engines.Engines.LikeFriendsPostsEngine;
using Engines.Engines.LikeHashTagEngine;
using Engines.Engines.RegistrationEngine;
using Engines.Engines.SearchUserFriendsEngine;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InstagramApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hashTag = "#Коложа";

            var driver = new ChromeDriver();
            
            var registrationEngine = new RegistrationEngine();
            var registrationModel = new RegistrationModel
            {
                UserName = "mydevpage",
                Password = "Ntvyjnf123"
            };
            registrationEngine.Execute(driver, registrationModel);

            var likeHashTagEngine = new SearchUserFriendsEngine();
            var likeHashTagModel = new SearchUserFriendsModel
            {
                UserPageLink = "https://www.instagram.com/grodnoin/"
            };
            likeHashTagEngine.Execute(driver, likeHashTagModel);

            //driver.Close(); 
        }
    }
}
