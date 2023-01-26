using OpenQA.Selenium;

namespace Core.Utils.Extensions
{
    public static class BrowserInteractions
    {
        public static void MaximizeBrowser(this IWebDriver driver)
        {
            if (driver != null)
                driver.Manage().Window.Maximize();
        }

        public static void DeleteAllCookies(this IWebDriver driver)
        {
            if (driver != null)
                driver!.Manage().Cookies.DeleteAllCookies();
        }
    }
}
