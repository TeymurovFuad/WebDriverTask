using OpenQA.Selenium;

namespace WebDriverTask.Core.Browser.Configuration
{
    public interface IBrowser
    {
        IBrowser GetInstance { get; }
        IWebDriver GetDriver();
        IWebDriver GetRemoteDriver();
        IBrowser SetOptions(DriverOptions? options);
    }

}
