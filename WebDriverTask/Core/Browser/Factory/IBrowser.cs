using OpenQA.Selenium;

namespace WebDriverTask.Core.Browser.Factory
{
    public interface IBrowser
    {
        static IBrowser GetInstance { get; }
        IWebDriver GetDriver();
        IWebDriver GetRemoteDriver();
        IBrowser SetOptions(DriverOptions? options);
    }

}
