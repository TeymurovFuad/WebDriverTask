using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using WebDriverTask.Core.Helpers;
using WebDriverTask.Core.WebDriverConfigs;

namespace WebDriverTask.Pages.Gmail.Logout.AccountDialog
{
    public static class AccountDialogElements
    {
        [FindsBy(How = How.Id, Using = "//iframe[@name='account']")]
        public static IWebElement AccountIFrame { get; private set; }

        [FindsBy(How = How.Id, Using = "//a[contains(@href, 'Logout')]")]
        public static IWebElement SingOutButton { get; private set; }

        private static string _openAccountDialogButton = "//a[contains(@aria-label, '{0}') and contains(@href, 'SignOut')]";

        public static IWebElement OpenAccountDialogButton(string email)
        {
            string formattedPath = StringHelper.FormatString(_openAccountDialogButton, email)!;
            return Driver.GetDriver().FindElement(By.XPath(formattedPath));
        }
    }
}
