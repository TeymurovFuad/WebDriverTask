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
    public class WebDriverBuilder: WebDriverFactory
    {
        private bool _isBuilt;

        public WebDriverBuilder(BrowserType browserType) : base(browserType) { }

        protected WebDriverBuilder Build()
        {
            CreateDriver();
            _isBuilt = true;
            return this;
        }

        public WebDriverBuilder AddArguments(string[] arguments)
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
