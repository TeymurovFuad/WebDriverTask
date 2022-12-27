using OpenQA.Selenium;
using WebDriverTask.Core.CustomExceptions;

namespace WebDriverTask.Core.WebDriver
{
    public abstract class Driver
    {
        private IWebDriver _webDriver;

        protected Driver() { }

        public IWebDriver GetDriver()
        {
            try
            {
                return _webDriver!;
            }
            catch (NullReferenceException nre)
            {
                throw new DriverException("Webdriver is not set yet", nre);
            }
        }

        public Driver Instance()
        {
            return this;
        }

        protected void SetDriver(IWebDriver driver)
        {
            if(_webDriver!=null)
                _webDriver = driver;
        }

        public bool isBuilt()
        {
            return _webDriver != null;
        }

        public string GetUrl()
        {
            return _webDriver!.Url;
        }

        public void SwitchToFrame(IWebElement frame)
        {
            _webDriver.SwitchTo().Frame(frame);
        }

        public void SwitchToMain()
        {
            _webDriver.SwitchTo().DefaultContent();
        }

        public void GoToUrl(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

        public void Close()
        {
            _webDriver?.Close();
        }
    }
}
