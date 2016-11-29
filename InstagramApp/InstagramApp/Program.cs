using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Commands.Functionality;
using DataBase.QueriesAndCommands.Queries.Functionality;
using Engines.Engines.GetUserIdEngine;
using Engines.Exceptions;
using InstagramApp.Properties;
using InstagramApp.Tools;
using Newtonsoft.Json;
using OpenQA.Selenium;
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

        private class CookieMainData
        {
            public string Name { get; set; }

            public DateTime? Expiry { get; set; }

            public string Domain { get; set; }

            public string Path { get; set; }

            public string Value { get; set; }
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

            var accounts = new AllowedAccountsProvider().GetAllowedAccounts().ToList();

            var tasks = new List<Task>();

            if (accounts.Contains(AccountName.Augustovski))
            {
                tasks.Add(RegisterProccess<AugustovskiContext>());
            }

            if (accounts.Contains(AccountName.Karina))
            {
                tasks.Add(RegisterProccess<KarinaContext>());
            }

            if (accounts.Contains(AccountName.Ozerny))
            {
                tasks.Add(RegisterProccess<OzernyContext>());
            }

            if (accounts.Contains(AccountName.Galaxy))
            {
                tasks.Add(RegisterProccess<GalaxyContext>());
            }

            if (accounts.Contains(AccountName.SalsaRika))
            {
                tasks.Add(RegisterProccess<SalsaRikaContext>());
            }

            if (accounts.Contains(AccountName.Kioto))
            {
                tasks.Add(RegisterProccess<KiotoContext>());
            }

            if (accounts.Contains(AccountName.Nazar))
            {
                tasks.Add(RegisterProccess<NazarContext>());
            }

            if (accounts.Contains(AccountName.Lajki))
            {
                tasks.Add(RegisterProccess<LajkiContext>());
            }

            if (accounts.Contains(AccountName.Nikon))
            {
                tasks.Add(RegisterProccess<NikonContext>());
            }

            if (accounts.Contains(AccountName.GreenDozor))
            {
                tasks.Add(RegisterProccess<GreenDozorContext>());
            }

            if (accounts.Contains(AccountName.Mirelle))
            {
                tasks.Add(RegisterProccess<MirelleContext>());
            }

            if (accounts.Contains(AccountName.Canon))
            {
                tasks.Add(RegisterProccess<CanonContext>());
            }

            if (accounts.Contains(AccountName.Egor))
            {
                tasks.Add(RegisterProccess<EgorContext>());
            }

            if (accounts.Contains(AccountName.Gadanie))
            {
                tasks.Add(RegisterProccess<GadanieContext>());
            }

            if (accounts.Contains(AccountName.Anastasiya))
            {
                tasks.Add(RegisterProccess<AnastasiyaContext>());
            }

            if (accounts.Contains(AccountName.Etalon))
            {
                tasks.Add(RegisterProccess<EtalonContext>());
            }

            if (accounts.Contains(AccountName.Sport))
            {
                tasks.Add(RegisterProccess<SportContext>());
            }

            if (accounts.Contains(AccountName.GrodnoOfficial))
            {
                tasks.Add(RegisterProccess<GrodnoOfficialContext>());
            }

            if (accounts.Contains(AccountName.MyGrodno))
            {
                tasks.Add(RegisterProccess<MyGrodnoContext>());
            }

            if (accounts.Contains(AccountName.Mumia))
            {
                tasks.Add(RegisterProccess<MumiaContext>());
            }

            if (accounts.Contains(AccountName.Sto))
            {
                tasks.Add(RegisterProccess<StoContext>());
            }

            if (accounts.Contains(AccountName.Sto2))
            {
                tasks.Add(RegisterProccess<Sto2Context>());
            }

            Task.WhenAll(spamTask.ToArray());

            while (true)
            {
                Console.ReadLine();
                // To stop cancelling the allpication 
            }
        }
    }
}
