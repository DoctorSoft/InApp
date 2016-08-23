using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataBase.Contexts;
using Engines.Exceptions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace InstagramApp
{
    public class Program
    {
        /// <summary>
        /// My Dev Page
        /// </summary>
        private static readonly ChromeDriver myDevPageDriver = new ChromeDriver();

        private static readonly InstagramService myDevPageInstagramService = new InstagramService();

        private static readonly TaskRunner MyDevPageTaskRunner = new TaskRunner();

        private static Task RegisterMyDevPageProccess()
        {
            // My Dev Page Jobs
            var myDevPageAproveUsersTokenSource = new CancellationTokenSource();

            return Task.Run(() => MyDevPageTaskRunner.SecondPageRunPeriodically(() =>
                MyDevPageTaskRunner.Run<MyDevPageContext>(myDevPageInstagramService, myDevPageDriver),
                TimeSpan.FromSeconds(30),
                myDevPageAproveUsersTokenSource.Token), myDevPageAproveUsersTokenSource.Token);
        } 


        /// <summary>
        /// Second Page
        /// </summary>
        private static readonly ChromeDriver secondPageDriver = new ChromeDriver();
 
        private static readonly InstagramService secondPageInstagramService = new InstagramService();

        private static readonly TaskRunner SecondPageTaskRunner = new TaskRunner();

        private static Task RegisterSecondPageProcess()
        {
            // Second Page Jobs
            var secondPageAproveUsersTokenSource = new CancellationTokenSource();

            return Task.Run(() => SecondPageTaskRunner.SecondPageRunPeriodically(() =>
                SecondPageTaskRunner.Run<SecondPageContext>(secondPageInstagramService, secondPageDriver),
                TimeSpan.FromSeconds(30),
                secondPageAproveUsersTokenSource.Token), secondPageAproveUsersTokenSource.Token);
        }

        /// <summary>
        /// Task Runner
        /// </summary>
        private class TaskRunner
        {
            public async Task SecondPageRunPeriodically(Action action, TimeSpan interval, CancellationToken token)
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
                var actions = new List<Action<RemoteWebDriver, TContext>>
                {
                    
                    service.ClearOldMedia, //2 days
                    service.SearchNewUsers,
                    service.FollowUsers,
                    service.ApproveUsers,
                    service.UnfollowUsers
                    
                    
                };


                foreach (var action in actions)
                {
                    using (var context = new TContext())
                    {
                        try
                        {
                            action(driver, context);
                        }
                        catch (CaptchaException exception)
                        {
                            service.HandleCaptchaException(driver, context);
                        }
                        catch (Exception exception)
                        {
                            // todo: add system of logging of exceptions
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
                RegisterMyDevPageProccess(), RegisterSecondPageProcess()
            };

            Task.WhenAll(tasks.ToArray());

            while (true)
            {
                // To stop cancelling the allpication 
            }
        }
    }
}
