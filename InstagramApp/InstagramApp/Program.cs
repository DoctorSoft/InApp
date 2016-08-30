﻿using System;
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
        private static readonly ChromeDriver ozernyDriver = new ChromeDriver();

        private static readonly InstagramService ozernyInstagramService = new InstagramService();

        private static readonly TaskRunner ozernyTaskRunner = new TaskRunner();

        private static Task RegisterOzernyProccess()
        {
            // My Dev Page Jobs
            var ozernyAproveUsersTokenSource = new CancellationTokenSource();

            return Task.Run(() => ozernyTaskRunner.RunPeriodically(() =>
                ozernyTaskRunner.Run<OzernyContext>(ozernyInstagramService, ozernyDriver),
                TimeSpan.FromSeconds(30),
                ozernyAproveUsersTokenSource.Token), ozernyAproveUsersTokenSource.Token);
        } 


        /// <summary>
        /// Second Page
        /// </summary>
        private static readonly ChromeDriver dvurechenskyDriver = new ChromeDriver();
 
        private static readonly InstagramService dvurechenskyInstagramService = new InstagramService();

        private static readonly TaskRunner dvurechenskyTaskRunner = new TaskRunner();

        private static Task RegisterDvurechenskyProcess()
        {
            // Second Page Jobs
            var dvurechenskyAproveUsersTokenSource = new CancellationTokenSource();

            return Task.Run(() => dvurechenskyTaskRunner.RunPeriodically(() =>
                dvurechenskyTaskRunner.Run<DvurechenskyContext>(dvurechenskyInstagramService, dvurechenskyDriver),
                TimeSpan.FromSeconds(30),
                dvurechenskyAproveUsersTokenSource.Token), dvurechenskyAproveUsersTokenSource.Token);
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
                var actions = new List<Action<RemoteWebDriver, TContext>>
                {
                    service.SynchOwnerFollowings,
                    service.SearchNewUsers,
                    service.FollowUsers,
                    service.SynchOwnerFriends,
                    service.UnfollowUsers,
                    service.ClearOldMedia, //2 days
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
                RegisterOzernyProccess(), RegisterDvurechenskyProcess()
            };

            Task.WhenAll(tasks.ToArray());

            while (true)
            {
                // To stop cancelling the allpication 
            }
        }
    }
}
