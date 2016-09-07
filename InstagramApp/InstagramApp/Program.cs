using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Constants;
using DataBase.Contexts;
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
        private static readonly ChromeDriver ozernyDriver = new ChromeDriver();

        private static readonly InstagramService ozernyInstagramService = new InstagramService();

        private static readonly TaskRunner ozernyTaskRunner = new TaskRunner();

        private static Task RegisterOzernyProccess()
        {
            // My Dev Page Jobs
            var ozernyAproveUsersTokenSource = new CancellationTokenSource();

            return Task.Run(() => ozernyTaskRunner.RunPeriodically(() =>
                ozernyTaskRunner.Run<OzernyContext>(ozernyInstagramService, ozernyDriver),
                TimeSpan.FromSeconds(5),
                ozernyAproveUsersTokenSource.Token), ozernyAproveUsersTokenSource.Token);
        } 


        /// <summary>
        /// Galaxy
        /// </summary>
        private static readonly ChromeDriver galaxyDriver = new ChromeDriver();

        private static readonly InstagramService galaxyInstagramService = new InstagramService();

        private static readonly TaskRunner galaxyTaskRunner = new TaskRunner();

        private static Task RegisterGalaxyProcess()
        {
            // Second Page Jobs
            var galaxyAproveUsersTokenSource = new CancellationTokenSource();

            return Task.Run(() => galaxyTaskRunner.RunPeriodically(() =>
                galaxyTaskRunner.Run<GalaxyContext>(galaxyInstagramService, galaxyDriver),
                TimeSpan.FromSeconds(5),
                galaxyAproveUsersTokenSource.Token), galaxyAproveUsersTokenSource.Token);
        }

        /// <summary>
        /// Kioto
        /// </summary>
        private static readonly ChromeDriver kiotoDriver = new ChromeDriver();

        private static readonly InstagramService kiotoInstagramService = new InstagramService();

        private static readonly TaskRunner kiotoTaskRunner = new TaskRunner();

        private static Task RegisterKiotoProccess()
        {
            // My Dev Page Jobs
            var kiotoAproveUsersTokenSource = new CancellationTokenSource();

            return Task.Run(() => kiotoTaskRunner.RunPeriodically(() =>
                kiotoTaskRunner.Run<KiotoContext>(kiotoInstagramService, kiotoDriver),
                TimeSpan.FromSeconds(5),
                kiotoAproveUsersTokenSource.Token), kiotoAproveUsersTokenSource.Token);
        }

        /// <summary>
        /// Milk
        /// </summary>
        private static readonly ChromeDriver milkDriver = new ChromeDriver();

        private static readonly InstagramService milkInstagramService = new InstagramService();

        private static readonly TaskRunner milkTaskRunner = new TaskRunner();

        private static Task RegisterMilkProccess()
        {
            // My Dev Page Jobs
            var milkAproveUsersTokenSource = new CancellationTokenSource();

            return Task.Run(() => milkTaskRunner.RunPeriodically(() =>
                milkTaskRunner.Run<MilkContext>(milkInstagramService, milkDriver),
                TimeSpan.FromSeconds(5),
                milkAproveUsersTokenSource.Token), milkAproveUsersTokenSource.Token);
        }

        /// <summary>
        /// Lajki
        /// </summary>
        private static readonly ChromeDriver lajkiDriver = new ChromeDriver();

        private static readonly InstagramService lajkiInstagramService = new InstagramService();

        private static readonly TaskRunner lajkiTaskRunner = new TaskRunner();

        private static Task RegisterLajkiProccess()
        {
            // My Dev Page Jobs
            var lajkiAproveUsersTokenSource = new CancellationTokenSource();

            return Task.Run(() => lajkiTaskRunner.RunPeriodically(() =>
                lajkiTaskRunner.Run<LajkiContext>(lajkiInstagramService, lajkiDriver),
                TimeSpan.FromSeconds(5),
                lajkiAproveUsersTokenSource.Token), lajkiAproveUsersTokenSource.Token);
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
                    {FunctionalityName.AddComments, service.AddComments} 
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
                RegisterOzernyProccess(), RegisterGalaxyProcess(), RegisterKiotoProccess(), RegisterMilkProccess(), RegisterLajkiProccess()
            };

            Task.WhenAll(tasks.ToArray());

            while (true)
            {
                // To stop cancelling the allpication 
            }
        }
    }
}
