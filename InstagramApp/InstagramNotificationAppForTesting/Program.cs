using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Constants;
using DataBase.Contexts.InnerTools;
using InstagramApp;
using InstagramApp.Tools;
using Tools.DatabaseSearcher;

namespace InstagramNotificationAppForTesting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var accounts = new AllowedAccountsProvider().GetAllowedAccounts().ToList();
            var settings = new AllowedAccountsProvider().GetSettings();

            var allowedBase = DataBaseSearcher.GetTypesWithAttribute(
                AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.FullName.Contains("DataBase")),
                name => accounts.Contains(name))
                .ToList().FirstOrDefault();


            var db = (DataBaseContext) Activator.CreateInstance(allowedBase.DataBaseType);
            var instagramService = new InstagramService();
            var follows = 0;
            var unfollows = 0;
            var likes = 0;
            var warning = false;

            var todayFollowers = new List<string>();

            using (var driver = instagramService.RegisterNewDriver(db.OpenCopyContext()))
            {

                driver.Navigate().GoToUrl("https://whatismyipaddress.com/");
                Thread.Sleep(TimeSpan.FromSeconds(15));

                var circlesCount = settings.Cicles;

                var followCountForCircle = settings.Follows;
                var unfollowCountForCircle = settings.UnFollows;
                var likeForCircle = settings.Likes;

                for (var circle = 0; circle < circlesCount; circle++)
                {
                    for (var followIndex = 0; followIndex < followCountForCircle; followIndex++)
                    {
                        follows++;
                        Thread.Sleep(TimeSpan.FromSeconds(15));
                        try
                        {
                            var result = instagramService.FollorUserWithStatus(driver, db, 3);
                        }
                        catch (Exception)
                        {
                        }
                    }

                    for (var unfollowIndex = 0; unfollowIndex < unfollowCountForCircle; unfollowIndex++)
                    {
                        unfollows++;
                        Thread.Sleep(TimeSpan.FromSeconds(15));
                        try
                        {
                            var result = instagramService.UnfollowUserWithStatus(driver, db, 3, todayFollowers);
                        }
                        catch (Exception)
                        {
                        }
                    }

                    for (var likeIndex = 0; likeIndex < likeForCircle; likeIndex++)
                    {
                        likes++;
                        Thread.Sleep(TimeSpan.FromSeconds(10));
                        try
                        {
                            instagramService.LikeMedias(driver, db);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }

                driver.Close();
            }
        }
    }
}
