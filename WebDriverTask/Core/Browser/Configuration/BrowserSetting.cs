using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Core.Browser.Configuration
{
    public abstract class BrowserSetting
    {
        private static DriverOptions DriverOptions { get; set; }
        protected BrowserSetting() { }

        public static void AddArguments(params string[] arguments)
        {
            if (Driver.isBuilt() && arguments != null && arguments.Length > 0)
                {
                switch (BrowserFactory.GetBrowserType())
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
                        throw new NotImplementedException();
                }
            }
        }

        public static void AddPreferences(Dictionary<string, object> preferences)
        {
            if (Driver.isBuilt() && preferences != null && preferences.Count > 0)
            {

                switch (BrowserFactory.GetBrowserType())
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
                        throw new NotImplementedException();
                }
            }
        }
    }
}
