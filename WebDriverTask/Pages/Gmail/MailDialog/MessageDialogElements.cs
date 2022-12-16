using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using WebDriverTask.Core.Helpers;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Pages.Gmail.MailDialog
{
    public static class MessageDialogElements
    {
        private const string _newMailDialogHeader = "New Message";
        private const string _mailDialogXPath = "//h2[div[text()='Compose:'] and div/span[text()='{0}']]";

        [FindsBy(How = How.XPath, Using = "//div[@name='to']//input")]
        public static IWebElement To { get; private set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='subjectbox']")]
        public static IWebElement Subject { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@aria-label='Message Body']")]
        public static IWebElement Body { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@role='button' and text()='Send']")]
        public static IWebElement SendButton { get; private set; }

        [FindsBy(How = How.XPath, Using = "//img[@aria-label='Save & close']")]
        public static List<IWebElement> SaveAndCloseButtons { get; private set; }


        public static List<IWebElement> MailDialogs(string dialogHeader)
        {
            string pathToDialog = StringHelper.FormatString(_mailDialogXPath, dialogHeader)!;
            return Driver.GetDriver().FindElements(By.XPath(pathToDialog)).ToList();
        }

        public static List<IWebElement> MailDialogs()
        {
            string pathToDialog = StringHelper.FormatString(_mailDialogXPath, _newMailDialogHeader)!;
            return Driver.GetDriver().FindElements(By.XPath(pathToDialog)).ToList();
        }

        public static string PathToMailDialog(string mailSubject)
        {
            return StringHelper.FormatString(_mailDialogXPath, mailSubject??_newMailDialogHeader)!;
        }
    }
}
