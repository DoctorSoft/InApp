using OpenQA.Selenium.Remote;

namespace InstagramApp.Engines
{
    public interface IEngine<TModel>
    {
        void Execute(RemoteWebDriver driver, TModel model);
    }
}
