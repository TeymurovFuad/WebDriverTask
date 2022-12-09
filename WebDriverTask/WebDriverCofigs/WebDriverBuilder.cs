using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverTask.Core;

namespace WebDriverTask.WebDriverConfigs
{
    public sealed class WebDriverBuilder
    {
        private Browser _browser;
        private bool _isBuilt;

        public WebDriverBuilder() { }

        public WebDriverBuilder Build(Browser browser)
        {
            _browser = browser;
            WebDriverFactory.CreateDriver(browser);
            _isBuilt = true;
            return this;
        }

        public WebDriverBuilder SetupDriver(string[] arguments)
        {
            if (_isBuilt && arguments != null && arguments.Length > 0)
            {
                switch (_browser)
                {
                    case Browser.Chrome:
                        ChromeOptions chromeOptions = new ChromeOptions();
                        foreach (string argument in arguments)
                        {
                            chromeOptions.AddArgument(argument);
                        }
                        break;
                    case Browser.Firefox:
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
