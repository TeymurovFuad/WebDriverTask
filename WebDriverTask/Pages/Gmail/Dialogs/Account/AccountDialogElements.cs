using OpenQA.Selenium;
using WebDriverTask.Core.Helpers;

namespace WebDriverTask.Pages.Gmail.Dialogs.Account
{
    public class AccountDialogElements: BasePage
    {
        IWebDriver webDriver { get; set; }
        public AccountDialogElements(IWebDriver driver)
        {
            webDriver = driver;
        }

        public readonly string AccountIFrameXPath = "//iframe[@name='account']";
        public IWebElement AccountIFrame => webDriver.FindElements(By.XPath(AccountIFrameXPath)).First();

        public readonly string SingOutButtonXPath = "//a[contains(@href, 'Logout')]";
        public IWebElement SingOutButton => webDriver.FindElements(By.XPath(SingOutButtonXPath)).First();

        private string _openAccountDialogButtonXPath = "//a[contains(@aria-label, '{0}') and contains(@href, 'SignOut')]";

        public IWebElement OpenAccountDialogButton(string email)
        {
            string formattedPath = StringHelper.FormatString(_openAccountDialogButtonXPath, email)!;
            return webDriver.FindElement(By.XPath(formattedPath));
        }
    }
}
