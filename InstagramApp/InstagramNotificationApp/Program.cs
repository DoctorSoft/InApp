using System;
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

            using (var driver = instagramService.RegisterNewDriver(db.OpenCopyContext()))
            {

                var circlesCount = settings.Cicles;

                var followCountForCircle = settings.Follows;
                var unfollowCountForCircle = settings.UnFollows;
                var likeForCircle = settings.Likes;

                var failLimit = 10;
                var fails = 0;

                var receivers = new[] {"SysDocRemainder+remainder@gmail.com", "ArcherFromGrodno@gmail.com", "tomash33@mail.ru"};

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
                        Thread.Sleep(TimeSpan.FromSeconds(15));
                        try
                        {
                            var result = instagramService.FollorUserWithStatus(driver, db, 3);
                            if (result != WorkStatus.Success)
                            {
                                fails++;
                            }
                        }
                        catch (Exception)
                        {
                            fails++;
                        }

                        if (fails > failLimit)
                        {
                            NotificationService.NotificationService.SendNotification(
                                string.Format(
                                    "Работа аккаунта {0} была остановлена из-за большого количества ошибок при подписках ({1} действий)",
                                    db.GetAccountName().ToString("G"), circle*followCountForCircle + followIndex),
                                receivers);
                            driver.Close();
                            return;
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
                        Thread.Sleep(TimeSpan.FromSeconds(15));
                        try
                        {
                            var result = instagramService.UnfollowUserWithStatus(driver, db, 3);
                            if (result != WorkStatus.Success)
                            {
                                fails++;
                            }
                        }
                        catch (Exception)
                        {
                            fails++;
                        }

                        if (fails > failLimit)
                        {
                            NotificationService.NotificationService.SendNotification(
                                string.Format(
                                    "Работа аккаунта {0} была остановлена из-за большого количества ошибок при отписках ({1} действий)",
                                    db.GetAccountName().ToString("G"), circle*unfollowCountForCircle + unfollowIndex),
                                receivers);
                            driver.Close();
                            return;
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
                            NotificationService.NotificationService.SendNotification(
                                string.Format(
                                    "Работа аккаунта {0} была остановлена из-за большого количества ошибок при лайках ({1} действий)",
                                    db.GetAccountName().ToString("G"), circle*likeForCircle + likeIndex), receivers);
                            driver.Close();
                            return;
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
                        db.GetAccountName().ToString("G"), followCountForCircle*circlesCount), receivers);
                driver.Close();
                return;
            }
        }
    }
}
