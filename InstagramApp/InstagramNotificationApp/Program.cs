using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Constants;
using DataBase.Contexts.InnerTools;
using InstagramApp;
using InstagramApp.Tools;
using Tools.DatabaseSearcher;

namespace InstagramNotificationApp
{
    public class Program
    {
        public static string GetStatistic(long failLimit, long fails, long circlesCount, long followCountForCircle,
            long unfollowCountForCircle, long likeForCircle, long follows, long unfollows, long likes, long circle)
        {
            return
                string.Format(
                    "статистика: ошибок подряд {0}/{1}, кругов {9}/{2}, добавлений  {3}/{4}, отписок {5}/{6}, лайков {7}/{8}",
                    fails, failLimit, circlesCount, follows, followCountForCircle*circlesCount, unfollows,
                    unfollowCountForCircle*circlesCount, likes, likeForCircle*circlesCount, circle);
        }

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

                var circlesCount = settings.Cicles;

                var followCountForCircle = settings.Follows;
                var unfollowCountForCircle = settings.UnFollows;
                var likeForCircle = settings.Likes;

                var failLimit = 5;
                var fails = 0;

                var receivers = new[] { "SysDocRemainder+remainder@gmail.com", "ArcherFromGrodno+insta@gmail.com", "tomash33@mail.ru", "megopixel91+insta@gmail.com " };

                NotificationService.NotificationService.SendNotification(
                    string.Format("Работа аккаунта {0} была начата для {1} действий",
                        db.GetAccountName().ToString("G"), followCountForCircle*circlesCount), receivers);

                for (var circle = 0; circle < circlesCount; circle++)
                {
                    try
                    {
                        instagramService.AddActivityHistoryMark(driver, db);
                    }
                    catch (Exception)
                    {
                    }

                    try
                    {
                        instagramService.SaveMediaByHashTag(driver, db);
                    }
                    catch (Exception)
                    {
                    }

                    fails = 0;
                    for (var followIndex = 0; followIndex < followCountForCircle; followIndex++)
                    {
                        follows++;
                        Thread.Sleep(TimeSpan.FromSeconds(15));
                        try
                        {
                            var result = instagramService.FollorUserWithStatus(driver, db, 3);
                            if (result.WorkStatus != WorkStatus.Success)
                            {
                                fails++;
                            }
                            else
                            {
                                todayFollowers.Add(result.User);
                                fails = 0;
                            }
                        }
                        catch (Exception)
                        {
                            fails++;
                        }

                        if (fails > failLimit)
                        {
                            if (warning)
                            {
                                NotificationService.NotificationService.SendNotification(
                                    string.Format(
                                        "Работа аккаунта {0} была остановлена из-за большого количества ошибок при подписках ({1})",
                                        db.GetAccountName().ToString("G"), GetStatistic(failLimit, fails, circlesCount, followCountForCircle, unfollowCountForCircle, likeForCircle, follows, unfollows, likes, circle)),
                                    receivers);

                                driver.Close();
                                return;
                            }
                            else
                            {
                                warning = true;
                                NotificationService.NotificationService.SendNotification(
                                    string.Format(
                                        "Работа аккаунта {0} была нарушена из-за большого количества ошибок при подписках, переключаемся на другую задачу ({1})",
                                        db.GetAccountName().ToString("G"), GetStatistic(failLimit, fails, circlesCount, followCountForCircle, unfollowCountForCircle, likeForCircle, follows, unfollows, likes, circle)),
                                    receivers);
                                break;
                            }
                        }
                    }

                    try
                    {
                        instagramService.SaveMediaByHashTag(driver, db);
                    }
                    catch (Exception)
                    {
                    }

                    fails = 0;
                    for (var unfollowIndex = 0; unfollowIndex < unfollowCountForCircle; unfollowIndex++)
                    {
                        unfollows++;
                        Thread.Sleep(TimeSpan.FromSeconds(15));
                        try
                        {
                            var result = instagramService.UnfollowUserWithStatus(driver, db, 3, todayFollowers);
                            if (result != WorkStatus.Success)
                            {
                                fails++;
                            }
                            else
                            {
                                fails = 0;
                            }
                        }
                        catch (Exception)
                        {
                            fails++;
                        }

                        if (fails > failLimit)
                        {
                            warning = true;
                            NotificationService.NotificationService.SendNotification(
                                string.Format(
                                    "Работа аккаунта {0} была нарушена из-за большого количества ошибок при отписках, переключаемся на другую задачу ({1})",
                                    db.GetAccountName().ToString("G"), GetStatistic(failLimit, fails, circlesCount, followCountForCircle, unfollowCountForCircle, likeForCircle, follows, unfollows, likes, circle)),
                                receivers);
                            break;
                        }
                    }

                    try
                    {
                        instagramService.SaveMediaByHashTag(driver, db);
                    }
                    catch (Exception)
                    {
                    }

                    fails = 0;
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
                            fails++;
                        }

                        if (fails > failLimit)
                        {
                            
                            warning = true;
                            NotificationService.NotificationService.SendNotification(
                                string.Format(
                                    "Работа аккаунта {0} была нарушена из-за большого количества ошибок при лайках, переключаемся на другую задачу ({1})",
                                    db.GetAccountName().ToString("G"), GetStatistic(failLimit, fails, circlesCount, followCountForCircle, unfollowCountForCircle, likeForCircle, follows, unfollows, likes, circle)),
                                receivers);
                            break;
                        }
                    }

                    try
                    {
                        instagramService.ClearOldMedia(driver, db);
                    }
                    catch (Exception)
                    {
                    }
                }

                NotificationService.NotificationService.SendNotification(
                    string.Format("Работа аккаунта {0} была остановлена из-за того, что норма была выполнена {1}",
                        db.GetAccountName().ToString("G"), GetStatistic(failLimit, fails, circlesCount, followCountForCircle, unfollowCountForCircle, likeForCircle, follows, unfollows, likes, circlesCount)), receivers);
                driver.Close();
                return;
            }
        }
    }
}
