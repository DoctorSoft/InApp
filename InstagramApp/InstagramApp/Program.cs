using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Engines.Engines.LikeFriendsPostsEngine;
using Engines.Engines.LikeHashTagEngine;
using Engines.Engines.RegistrationEngine;
using Engines.Engines.SearchUserFriendsEngine;
using Engines.Engines.SearchUserImagesEngine;
using OpenQA.Selenium;
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
