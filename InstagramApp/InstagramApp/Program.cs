using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Constants;
using DataBase.Contexts;
using Engines.Exceptions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
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

            var driver = new ChromeDriver(); //ChromeDriver(); or PhantomJSDriver();
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
                    {FunctionalityName.SynchOwnerFollowings, service.SynchOwnerFollowings},
                    {FunctionalityName.SearchNewUsers, service.SearchNewUsers},
                    {FunctionalityName.FollowUsers, service.FollowUsers},
                    {FunctionalityName.SynchOwnerFriends, service.SynchOwnerFriends},
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
            var tasks = new List<Task>
            {
                RegisterProccess<AugustovskiContext>(),
                RegisterProccess<ItransitionContext>(),
                RegisterProccess<SalsaRikaContext>(),
                RegisterProccess<OzernyContext>(), 
                RegisterProccess<GalaxyContext>(), 
                RegisterProccess<KiotoContext>(), 
                RegisterProccess<MilkContext>(), 
                RegisterProccess<LajkiContext>()
            };

            Task.WhenAll(tasks.ToArray());

            while (true)
            {
                // To stop cancelling the allpication 
            }
        }
    }
}
