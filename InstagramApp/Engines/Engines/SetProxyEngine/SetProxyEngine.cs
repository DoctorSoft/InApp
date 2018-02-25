using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.SetProxyEngine
{
    public class SetProxyEngine : AbstractEngine<SetProxyEngineModel, VoidResult>
    {
        protected override VoidResult ExecuteEngine(RemoteWebDriver driver, SetProxyEngineModel model)
        {
            //this.NavigateToUrl(driver, "https://www.google.by/?gws_rd=ssl");

            InputValues(model).Start();
            Task.WaitAll(new[] {GoToProxy(driver), InputValues(model)});

            Thread.Sleep(5000);

            return new VoidResult();
        }

        private async Task GoToProxy(RemoteWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.google.by/?gws_rd=ssl");
        }

        private async Task InputValues(SetProxyEngineModel model)
        {
            //return;
            await Task.Delay(10000);

            const string testWord = "TEST";
            foreach (var nextChar in testWord)
            {
                SendKeys.SendWait(nextChar.ToString());
                await Task.Delay(100);
            }

            for (var index = 0; index < testWord.Length * 2; index++)
            {
                SendKeys.SendWait("{BACKSPACE}");
                await Task.Delay(50);
            }

            await Task.Delay(1000);

            foreach (var nextChar in model.ProxyLogin)
            {
                SendKeys.SendWait(nextChar.ToString());
                await Task.Delay(100);
            }

            await Task.Delay(1000);

            SendKeys.SendWait("{TAB}");

            await Task.Delay(1000);

            foreach (var nextChar in model.ProxyPassword)
            {
                SendKeys.SendWait(nextChar.ToString());
                await Task.Delay(100);
            }

            await Task.Delay(1000);

            SendKeys.SendWait("{ENTER}");
        }
    }
}
