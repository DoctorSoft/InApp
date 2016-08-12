using System;
using System.Threading;
using System.Threading.Tasks;
using DataBase.Contexts;
using Hangfire;
using Hangfire.SqlServer;
using OpenQA.Selenium.Chrome;

namespace InstagramApp
{
    public class Program
    {
        /// <summary>
        /// My Dev Page
        /// </summary>
        private static readonly ChromeDriver myDevPageDriver = new ChromeDriver();

        private static readonly InstagramService myDevPageInstagramService = new InstagramService();

        private static async Task MyDevPageRunPeriodically(Action action, TimeSpan interval, CancellationToken token)
        {
            while (true)
            {
                action();
                await Task.Delay(interval, token);
            }
        }

        /// <summary>
        /// Second Page
        /// </summary>
        private static readonly ChromeDriver secondPageDriver = new ChromeDriver();
 
        private static readonly InstagramService secondPageInstagramService = new InstagramService();

        private static async Task SecondPageRunPeriodically(Action action, TimeSpan interval, CancellationToken token)
        {
            while (true)
            {
                action();
                await Task.Delay(interval, token);
            }
        }

        /// <summary>
        /// Run Jobs
        /// </summary>
        public static void Main(string[] args)
        {
            // My Dev Page Jobs
            var myDevPageAproveUsersTokenSource = new CancellationTokenSource();

            var myDevPageApproveUsersTask = MyDevPageRunPeriodically(() =>
            {
                using (var context = new MyDevPageContext())
                {
                    myDevPageInstagramService.ApproveUsers(myDevPageDriver, context);
                }

                Task.Delay(TimeSpan.FromMinutes(1));

                using (var context = new MyDevPageContext())
                {
                    myDevPageInstagramService.SearchNewUsers(myDevPageDriver, context);
                }

                Task.Delay(TimeSpan.FromMinutes(1));

                using (var context = new MyDevPageContext())
                {
                    myDevPageInstagramService.FollowUsers(myDevPageDriver, context);
                }

            }, TimeSpan.FromMinutes(1), myDevPageAproveUsersTokenSource.Token);
            
            // Second Page Jobs
            var secondPageAproveUsersTokenSource = new CancellationTokenSource();

            var secondPageApproveUsersTask = SecondPageRunPeriodically(() =>
            {
                using (var context = new SecondPageContext())
                {
                    secondPageInstagramService.ApproveUsers(secondPageDriver, context);
                }

                Task.Delay(TimeSpan.FromMinutes(1));

                using (var context = new SecondPageContext())
                {
                    secondPageInstagramService.SearchNewUsers(secondPageDriver, context);
                }

                Task.Delay(TimeSpan.FromMinutes(1));

                using (var context = new SecondPageContext())
                {
                    secondPageInstagramService.FollowUsers(secondPageDriver, context);
                }

            }, TimeSpan.FromMinutes(1), secondPageAproveUsersTokenSource.Token);

            while (true)
            {
                // To stop cancelling the allpication 
            }
        }
    }
}
