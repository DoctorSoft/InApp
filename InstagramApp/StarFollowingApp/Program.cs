using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Commands.Functionality;
using DataBase.QueriesAndCommands.Queries.Functionality;
using Engines.Exceptions;
using InstagramApp;
using InstagramApp.Tools;
using OpenQA.Selenium.Remote;
using Tools.DatabaseSearcher;

namespace StarFollowingApp
{
    public class Program
    {
        private static Task RegisterProccess(DataBaseContext context)
        {
            // My Dev Page Jobs
            var aproveUsersTokenSource = new CancellationTokenSource();

            var instagramService = new InstagramService();

            var driver = instagramService.RegisterNewDriver(context.OpenCopyContext());
            var taskRunner = new TaskRunner();

            return Task.Run(() => taskRunner.RunPeriodically(() =>
                taskRunner.Run(instagramService, driver, context.OpenCopyContext()),
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
            
            public void Run(InstagramService service, RemoteWebDriver driver, DataBaseContext contextData)
            {
                using (var context = contextData.OpenCopyContext())
                {
                    try
                    {

                        new StarService().FollowStar(driver, context);

                        Thread.Sleep(TimeSpan.FromMinutes(1));

                        new StarService().UnfollowStar(driver, context);
                        
                        Thread.Sleep(TimeSpan.FromMinutes(1));

                    }
                    catch (CaptchaException exception)
                    {
                        service.HandleCaptchaException(driver, context);
                    }
                    catch (Exception exception)
                    {
                        try
                        {
                            new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                            {
                                Note = "Exception: " + exception.Message,
                                Name = FunctionalityName.FollowUsers,
                                WorkStatus = WorkStatus.Exception
                            });
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            var accounts = new AllowedAccountsProvider().GetAllowedAccounts().ToList();

            var tasks = new List<Task>();

            var allowedBases = DataBaseSearcher.GetTypesWithAttribute(
                AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.FullName.Contains("DataBase")),
                name => accounts.Contains(name))
                .ToList();

            foreach (var allowedBase in allowedBases)
            {
                var db = (DataBaseContext)Activator.CreateInstance(allowedBase.DataBaseType);
                tasks.Add(RegisterProccess(db));
            }

            while (true)
            {
                Console.ReadLine();
                // To stop cancelling the allpication 
            }
        }
    }
}
