using System;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using Constants;
using DataBase.Contexts.InnerTools;
using InstagramApp;
using Tools.DatabaseSearcher;
using Timer = System.Timers.Timer;

namespace SwitchFollowingWindowsService
{
    public partial class MainService : ServiceBase
    {
        private Timer mainTimer = null;

        public MainService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Thread.Sleep(20000);
            mainTimer = new Timer();
            mainTimer.Elapsed += OnMainTimerTick;
            mainTimer.Interval = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;

            //mainTimer.Start();
            mainTimer.Enabled = true;
            OnMainTimerTick(mainTimer, EventArgs.Empty);
        }

        protected override void OnStop()
        {
            mainTimer.Enabled = false;
        }

        private void OnMainTimerTick(object obj, EventArgs args)
        {
            var accounts = new[]
            {
                AccountName.Kioto,
                AccountName.MyGrodno,
                AccountName.GrodnoOfficial,
                AccountName.SystemDoctor, 
            };

            var bases = DataBaseSearcher.GetTypesWithAttribute(
                AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.FullName.Contains("DataBase")),
                name => accounts.Contains(name))
                .ToList();

            var service = new InstagramService();

            foreach (var account in bases)
            {
                var db = (DataBaseContext)Activator.CreateInstance(account.DataBaseType);
                service.SwitchFollowingPolicy(db);
            }
        }
    }
}
