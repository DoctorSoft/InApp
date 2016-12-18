using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.SetProxyEngine
{
    public class SetProxyEngine : AbstractEngine<SetProxyEngineModel, VoidResult>
    {
        protected override VoidResult ExecuteEngine(RemoteWebDriver driver, SetProxyEngineModel model)
        {
            this.NavigateToUrl(driver, "https://www.google.by/?gws_rd=ssl");

            const string testWord = "TEST";
            foreach (var nextChar in testWord)
            {
                SendKeys.SendWait(nextChar.ToString());
                Thread.Sleep(100);
            }

            for (var index = 0; index < testWord.Length*2; index++)
            {
                SendKeys.SendWait("{BACKSPACE}");
                Thread.Sleep(50);
            }

            Thread.Sleep(1000);

            foreach (var nextChar in model.ProxyLogin)
            {
                SendKeys.SendWait(nextChar.ToString());
                Thread.Sleep(100);
            }

            Thread.Sleep(1000);

            SendKeys.SendWait("{TAB}");

            Thread.Sleep(1000);

            foreach (var nextChar in model.ProxyPassword)
            {
                SendKeys.SendWait(nextChar.ToString());
                Thread.Sleep(100);
            }

            Thread.Sleep(1000);
            
            SendKeys.SendWait("{ENTER}");

            Thread.Sleep(1000);

            return new VoidResult();
        }
    }
}
