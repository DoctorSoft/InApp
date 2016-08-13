using System;
using System.Threading;
using System.Threading.Tasks;
using DataBase.Contexts;
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


        /// <summary>
        /// Second Page
        /// </summary>
        private static readonly ChromeDriver secondPageDriver = new ChromeDriver();
 
        private static readonly InstagramService secondPageInstagramService = new InstagramService();

        private static readonly TaskRunner SecondPageTaskRunner = new TaskRunner();

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

            public void Run<TContext>(InstagramService service, RemoteWebDriver driver, CancellationTokenSource cancellationTokenSource)
                where TContext : DataBaseContext, new()
            {
                using (var context = new TContext())
                {
                    service.SearchNewUsers(driver, context);
                }

                Task.Delay(TimeSpan.FromMinutes(1), cancellationTokenSource.Token);

                using (var context = new TContext())
                {
                    service.FollowUsers(driver, context);
                }

                Task.Delay(TimeSpan.FromMinutes(1), cancellationTokenSource.Token);

                using (var context = new TContext())
                {
                    service.ApproveUsers(driver, context);
                }
            }
        }

        /// <summary>
        /// Run Jobs
        /// </summary>
        public static void Main(string[] args)
        {
            // My Dev Page Jobs
            var myDevPageAproveUsersTokenSource = new CancellationTokenSource();

            var myDevPageApproveUsersTask = MyDevPageTaskRunner.SecondPageRunPeriodically(() => 
                MyDevPageTaskRunner.Run<MyDevPageContext>(myDevPageInstagramService, myDevPageDriver, myDevPageAproveUsersTokenSource), 
                TimeSpan.FromMinutes(1), 
                myDevPageAproveUsersTokenSource.Token);
            
            // Second Page Jobs
            var secondPageAproveUsersTokenSource = new CancellationTokenSource();

            var secondPageApproveUsersTask = SecondPageTaskRunner.SecondPageRunPeriodically(() => 
                SecondPageTaskRunner.Run<SecondPageContext>(secondPageInstagramService, secondPageDriver, secondPageAproveUsersTokenSource), 
                TimeSpan.FromMinutes(1), 
                secondPageAproveUsersTokenSource.Token);

            while (true)
            {
                // To stop cancelling the allpication 
            }
        }
    }
}
