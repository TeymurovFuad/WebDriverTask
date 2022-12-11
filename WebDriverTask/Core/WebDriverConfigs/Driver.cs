using OpenQA.Selenium;
using WebDriverTask.Core.CustomExceptions;

namespace WebDriverTask.Core.WebDriverConfigs
{
    public static class Driver
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

        public static void SetDriver(IWebDriver driver)
        {
            _webDriver = driver;
        }

        public static string GetUrl()
        {
            return _webDriver!.Url;
        }

        public static void Close()
        {
            if (_webDriver != null)
            {
                _webDriver.Close();
                _webDriver.Dispose();
                _webDriver = null;
            }
        }
    }
}
