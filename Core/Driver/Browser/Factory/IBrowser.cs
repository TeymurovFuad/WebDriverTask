using OpenQA.Selenium;

namespace Core.Browser.Factory
{
    public interface IBrowser
    {
        static IBrowser GetInstance { get; }
        IWebDriver GetDriver();
        IWebDriver GetRemoteDriver();
        IBrowser SetOptions(DriverOptions? options);
    }

}
