using System.Data;
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

            Thread.Sleep(1000);

            SendKeys.SendWait(model.ProxyLogin);

            Thread.Sleep(1000);

            SendKeys.SendWait("{TAB}");

            Thread.Sleep(1000);

            SendKeys.SendWait(model.ProxyPassword);

            Thread.Sleep(1000);
            
            SendKeys.SendWait("{ENTER}");

            Thread.Sleep(1000);

            return new VoidResult();
        }
    }
}
