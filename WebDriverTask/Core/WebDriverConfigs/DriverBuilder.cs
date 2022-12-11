using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverTask.Core.BrowserConfigs;

namespace WebDriverTask.Core.WebDriverConfigs
{
    public class DriverBuilder: DriverFactory
    {
        private bool _isBuilt;

        public DriverBuilder(BrowserType browserType) : base(browserType) { }

        protected DriverBuilder Build()
        {
            CreateDriver();
            _isBuilt = true;
            return this;
        }

        public DriverBuilder AddArguments(params string[] arguments)
        {
            if (_isBuilt && arguments != null && arguments.Length > 0)
            {
                switch (_browserType)
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
                        throw new ArgumentException($"Wrong browser was passed: {_browserType}");
                }
            }
            return this;
        }
    }
}
