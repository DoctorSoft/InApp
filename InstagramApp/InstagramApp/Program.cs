using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Commands.Functionality;
using DataBase.QueriesAndCommands.Queries.Functionality;
using Engines.Exceptions;
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

            var instagramService = new InstagramService();

            var driver = instagramService.RegisterNewDriver(new TContext());
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

            private FunctionalityWithTokenModel GetFunctionality<TContext>(InstagramService service, RemoteWebDriver driver, TContext context)
                where TContext : DataBaseContext, new()
            {
                try
                {
                    return service.GetFreeFunctionality(driver, context);

                }
                catch (Exception exception)
                {
                    new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                    {
                        Note = "Get Functionality Exception: " + exception.Message,
                        Name = FunctionalityName.AddActivityHistoryMark,
                        WorkStatus = WorkStatus.Exception
                    });

                    Thread.Sleep(TimeSpan.FromSeconds(10));

                    return GetFunctionality(service, driver, context);
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
                    {FunctionalityName.AddActivityHistoryMark, service.AddActivityHistoryMark} 
                };

                using (var context = new TContext())
                {
                    var actionData = GetFunctionality(service, driver, context);

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
                            try
                            {
                                new SetFunctionalityRecordCommandHandler(context).Handle(new SetFunctionalityRecordCommand
                                {
                                    Note = "Exception: " + exception.Message,
                                    Name = actionData.FunctionalityName,
                                    WorkStatus = WorkStatus.Exception
                                });
                            }
                            catch (Exception)
                            {
                            }
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
                //RegisterProccess<KarinaContext>(), //Karina
                //RegisterProccess<SalsaRikaContext>(),
                //RegisterProccess<OzernyContext>(), 
                //RegisterProccess<GalaxyContext>(), 
                RegisterProccess<KiotoContext>(), 
                //RegisterProccess<NazarContext>(), 
                //RegisterProccess<LajkiContext>(),
                //RegisterProccess<NikonContext>(),
                //RegisterProccess<GreenDozorContext>(),
                //RegisterProccess<MirelleContext>(),
                //RegisterProccess<CanonContext>(),
                //RegisterProccess<EgorContext>(),
                //RegisterProccess<GadanieContext>()

                //RegisterProccess<MumiaContext>(),
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
