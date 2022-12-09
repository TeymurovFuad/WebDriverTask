using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverTask.Core.BrowserConfigs;

namespace WebDriverTask.Core.WebDriverConfigs
{
    public sealed class WebDriverBuilder: WebDriverFactory
    {
        private BrowserType _browser;
        private bool _isBuilt;

        public WebDriverBuilder(BrowserType browserType): base(browserType)
        {
            _browser = browserType;
        }

        public WebDriverBuilder Build()
        {
            CreateDriver();
            _isBuilt = true;
            return this;
        }

        public WebDriverBuilder SetupDriver(string[] arguments)
        {
            if (_isBuilt && arguments != null && arguments.Length > 0)
            {
                switch (_browser)
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
                        throw new ArgumentException($"Wrong browser was passed: {_browser}");
                }
            }
            return this;
        }
    }
}
