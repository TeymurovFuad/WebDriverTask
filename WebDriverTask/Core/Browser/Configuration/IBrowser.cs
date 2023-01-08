using OpenQA.Selenium;

namespace WebDriverTask.Core.Browser.Configuration
{
    public interface IBrowser
    {
        IWebDriver GetDriver();
        IBrowser ConfigureRemoteDriver();
        IBrowser SetOptions(DriverOptions? options);
    }

}
