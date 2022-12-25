using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using WebDriverTask.Core.Helpers;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Pages.Gmail.Logout.AccountDialog
{
    public class AccountDialogElements: BaseElements
    {
        public const string AccountIFrameXPath = "//iframe[@name='account']";
        public static IWebElement AccountIFrame => GetDriver().FindElements(By.XPath(AccountIFrameXPath)).First();

        public const string SingOutButtonXPath = "//a[contains(@href, 'Logout')]";
        public static IWebElement SingOutButton => GetDriver().FindElements(By.XPath(SingOutButtonXPath)).First();

        private static string _openAccountDialogButtonXPath = "//a[contains(@aria-label, '{0}') and contains(@href, 'SignOut')]";

        public static IWebElement OpenAccountDialogButton(string email)
        {
            string formattedPath = StringHelper.FormatString(_openAccountDialogButtonXPath, email)!;
            return Core.WebDriver.Driver.GetDriver().FindElement(By.XPath(formattedPath));
        }
    }
}
