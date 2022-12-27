using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Core.Browser.Configuration
{
    public sealed class BrowserSetting
    {
        private readonly Driver _driver;
        private readonly BrowserType _browserType;
        public BrowserSetting(Driver driver, BrowserType browserType)
        {
            _driver = driver;
            _browserType = browserType;
        }

        public void AddArguments(params string[] arguments)
        {
            if (arguments!.Length > 0)
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
                        throw new NotImplementedException($"There is no implementation for a given browser type ({_browserType})");
                }
            }
        }

        public void AddPreferences(Dictionary<string, object> preferences)
        {
            if (preferences!.Count > 0)
            {
                switch (_browserType)
                {
                    case BrowserType.Chrome:
                        ChromeOptions chromeOptions = new ChromeOptions();
                        foreach (KeyValuePair<string, object> preference in preferences)
                        {
                            chromeOptions.AddUserProfilePreference(preference.Key, preference.Value);
                        }
                        break;
                    case BrowserType.Firefox:
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                        foreach (KeyValuePair<string, dynamic> preference in preferences)
                        {
                            firefoxOptions.SetPreference(preference.Key, preference.Value);
                        }
                        break;
                    default:
                        throw new NotImplementedException($"There is no implementation for a given browser type ({_browserType})");
                }
            }
        }
    }
}
