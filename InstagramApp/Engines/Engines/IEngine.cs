using OpenQA.Selenium.Remote;

namespace Engines.Engines
{
    public interface IEngine<TModel>
    {
        void Execute(RemoteWebDriver driver, TModel model);
    }
}
