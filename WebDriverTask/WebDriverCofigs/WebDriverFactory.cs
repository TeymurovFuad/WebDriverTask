using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverTask.Core;

namespace WebDriverTask.WebDriverConfigs
{
    public static class WebDriverFactory
    {
        public static void CreateDriver(Browser browser)
        {
            IWebDriver? driver = null;
            switch (browser)
            {
                case Browser.Chrome:
                    driver = new ChromeDriver();
                    break;
                case Browser.Firefox:
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentException($"Wrong browser was passed: {browser}");
            }
            WebDriver.SetWebDriver(driver);
        }
    }
}
