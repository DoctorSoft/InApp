using System;
using System.Threading;
using DataBase.Contexts.LikeApplication;
using DataBase.QueriesAndCommands.Queries.Proxy;
using InstagramApp;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LikeApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var likeService = new LikeApplicationService();
            var bots = likeService.GetRadnomBots();
            var medias = likeService.GetMidiasToLike();

            foreach (var bot in bots)
            {
                var instagramService = new InstagramService();
                var driver = instagramService.RegisterNewDriver(bot);
                
                instagramService.LikeMedias(driver, bot, medias);

                driver.Close();

                Thread.Sleep(2000);
            }
        }
    }
}
