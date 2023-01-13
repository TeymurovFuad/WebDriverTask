using OpenQA.Selenium;

namespace WebDriverTask.Core.Browser.Configuration
{
    public interface IBrowser
    {
        static IBrowser GetInstance { get; }
        IWebDriver GetDriver();
        IWebDriver GetRemoteDriver();
        IBrowser SetOptions(DriverOptions? options);
    }

}
