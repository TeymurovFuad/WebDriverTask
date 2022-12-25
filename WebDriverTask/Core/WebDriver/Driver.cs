using OpenQA.Selenium;
using WebDriverTask.Core.CustomExceptions;

namespace WebDriverTask.Core.WebDriver
{
    public abstract class Driver
    {
        private static IWebDriver? _webDriver = null;

        public static IWebDriver GetDriver()
        {
            try
            {
                return _webDriver!;
            }
            catch (NullReferenceException nre)
            {
                throw new DriverException("Webdriver is not set", nre);
            }
            catch(Exception e)
            {
                throw new DriverException("Not able to return webdriver" ,e);
            }
        }

        public static bool isBuilt()
        {
            return _webDriver != null;
        }

        protected static void SetDriver(IWebDriver driver)
        {
            _webDriver = driver;
        }

        public static string GetUrl()
        {
            return _webDriver!.Url;
        }

        public static void SwitchToFrame(IWebElement frame)
        {
            _webDriver.SwitchTo().Frame(frame);
        }

        public static void SwitchToMain()
        {
            _webDriver.SwitchTo().DefaultContent();
        }

        public static void GoToUrl(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

        public static void Close()
        {
            if (_webDriver != null)
            {
                _webDriver.Close();
            }
        }
    }
}
