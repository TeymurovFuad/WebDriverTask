using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverTask.Core.CustomExceptions;

namespace WebDriverTask.Core.Browser.Configuration
{
    public abstract class BrowserBuilder : BrowserFactory
    {
        private static bool _isBuilt;

        protected BrowserBuilder() { }

        protected static void Build(BrowserType browserType)
        {
            CreateBrowser(browserType);
            _isBuilt = true;
        }

        protected static void AddArguments(params string[] arguments)
        {
            BrowserType browserType = GetBrowserType();
            if (_isBuilt && arguments != null && arguments.Length > 0)
            {
                switch (browserType)
                {
                    case BrowserType.Chrome:
                        ChromeOptions chromeOptions = new ChromeOptions();
                        foreach (string argument in arguments)
                        {
                            chromeOptions.AddArgument(argument);
                        }
                        break;
                    case BrowserType.Firefox:
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                        foreach (string argument in arguments)
                        {
                            firefoxOptions.AddArgument(argument);
                        }
                        break;
                    default:
                        throw new BrowserTypeException($"Wrong browser was passed: {browserType}");
                }
            }
        }
    }
}
