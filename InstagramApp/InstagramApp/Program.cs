using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Constants;
using DataBase.Contexts;
using Engines.Engines.DetectLanguageEngine;
using Engines.Exceptions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace InstagramApp
{
    public class Program
    {
        /// <summary>
        /// Ozerny
        /// </summary>

        private static Task RegisterProccess<TContext>()
            where TContext : DataBaseContext, new()
        {
            // My Dev Page Jobs
            var aproveUsersTokenSource = new CancellationTokenSource();

            var driver = new ChromeDriver();
            var instagramService = new InstagramService();
            var taskRunner = new TaskRunner();

            return Task.Run(() => taskRunner.RunPeriodically(() =>
                taskRunner.Run<TContext>(instagramService, driver),
                TimeSpan.FromSeconds(5),
                aproveUsersTokenSource.Token), aproveUsersTokenSource.Token);
        } 

        /// <summary>
        /// Task Runner
        /// </summary>
        private class TaskRunner
        {
            public async Task RunPeriodically(Action action, TimeSpan interval, CancellationToken token)
            {
                while (true)
                {
                    action();
                    await Task.Delay(interval, token);
                }
            }

            public void Run<TContext>(InstagramService service, RemoteWebDriver driver)
                where TContext : DataBaseContext, new()
            {
                var actions = new Dictionary<FunctionalityName, Action<RemoteWebDriver, TContext>>
                {
                    {FunctionalityName.SaveMediaByHashTag, service.SaveMediaByHashTag},
                    {FunctionalityName.SaveMediaByHomePage, service.SaveMediaByHomePage}, 
                    {FunctionalityName.LikeMedias, service.LikeMedias},
                    {FunctionalityName.SearchNewUsers, service.SearchNewUsers},
                    {FunctionalityName.FollowUsers, service.FollowUsers},
                    {FunctionalityName.SearchUselessUsers, service.SearchUselessUsers},
                    {FunctionalityName.UnfollowUsers, service.UnfollowUsers},
                    {FunctionalityName.ClearOldMedia, service.ClearOldMedia}, 
                    {FunctionalityName.AddComments, service.AddComments},
                    {FunctionalityName.AddActivityHistoryMark, service.AddFollowersNote} 
                };

                using (var context = new TContext())
                {
                    var actionData = service.GetFreeFunctionality(driver, context);

                    if (service.FunctionalityIsAllowed(driver, context, actionData))
                    {
                        try
                        {
                            actions[actionData.FunctionalityName](driver, context);
                        }
                        catch (CaptchaException exception)
                        {
                            service.HandleCaptchaException(driver, context);
                        }
                        catch (Exception exception)
                        {
                            // todo: add system of logging of exceptions
                        }
                        finally
                        {
                            service.LeaveFunctionality(driver, context, actionData);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Run Jobs
        /// </summary>
        public static void Main(string[] args)
        {
            var spamTask = new List<Task>
            {
                //RegisterProccess<MakarovaSpamContext>(),
                //RegisterProccess<NovikovaSpamContext>(),
                //RegisterProccess<KrissSpamContext>()
            };

            var tasks = new List<Task>
            {
                //RegisterProccess<AugustovskiContext>(),
                RegisterProccess<KarinaContext>(), //Karina
                //RegisterProccess<SalsaRikaContext>(),
                //RegisterProccess<OzernyContext>(), 
                RegisterProccess<GalaxyContext>(), 
                RegisterProccess<KiotoContext>(), 
                RegisterProccess<NazarContext>(), 
                //RegisterProccess<LajkiContext>(),
                RegisterProccess<NikonContext>(),
                RegisterProccess<GreenDozorContext>(),
            };

            Task.WhenAll(spamTask.ToArray());

            while (true)
            {
                Console.ReadLine();
                // To stop cancelling the allpication 
            }
        }
    }
}
