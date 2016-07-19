using System.Collections.Generic;
using System.Linq;
using System.Threading;
using InstagramApp.Engines;
using InstagramApp.Engines.LikeFriendsPostsEngine;
using InstagramApp.Engines.LikeHashTagEngine;
using InstagramApp.Engines.RegistrationEngine;
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

            var likeFriendsPostsEngine = new LikeFriendsPostsEngine();
            likeFriendsPostsEngine.Execute(driver, new LikeFriendsPostsModel());

            /*var likeHashTagEngine = new LikeHashTagEngine();
            var likeHashTagModel = new LikeHashTagModel
            {
                HashTag = "#ПаркЖилибера"
            };
            likeHashTagEngine.Execute(driver, likeHashTagModel);*/

            //driver.Close(); 
        }
    }
}
