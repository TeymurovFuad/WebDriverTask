using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverTask.Core.BrowserConfigs;
using WebDriverTask.Core.CustomExceptions;

namespace WebDriverTask.Core.WebDriverConfigs
{
    public abstract class DriverBuilder: DriverFactory
    {
        private static bool _isBuilt;

        protected DriverBuilder() { }

        protected static void Build(BrowserType browserType)
        {
            CreateDriver(browserType);
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
