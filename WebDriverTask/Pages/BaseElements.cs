using OpenQA.Selenium;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Pages
{
    public abstract class BaseElements
    {
        protected DriverManager _driverManager;
        public BaseElements()
        {
            _driverManager = new DriverManager();
        }

        protected IWebDriver DriverInstance()
        {
            return _driverManager.GetDriverInstance();
        }
    }
}
