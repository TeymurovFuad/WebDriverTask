using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using WebDriverTask.Core.Helpers;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Pages.Gmail.MailDialog
{
    public class MessageDialogElements: BaseElements
    {
        private const string _newMailDialogHeader = "New Message";
        private const string _mailDialogXPath = "//h2[div[text()='Compose:'] and div/span[text()='{0}']]";

        public const string ToXPath = "//div[@name='to']//input";
        public static IWebElement To => GetDriver().FindElements(By.XPath(ToXPath)).First();

        public const string SubjectXPath = "//input[@name='subjectbox']";
        public static IWebElement Subject => GetDriver().FindElements(By.XPath(SubjectXPath)).First();

        public const string BodyXPath = "//div[@aria-label='Message Body']";
        public static IWebElement Body => GetDriver().FindElements(By.XPath(BodyXPath)).First();

        public const string SendButtonXPath = "//div[@role='button' and text()='Send']";
        public static IWebElement SendButton => GetDriver().FindElements(By.XPath(SendButtonXPath)).First();

        public const string SaveAndCloseButtonsXPath = "//img[@aria-label='Save & close']";
        public static List<IWebElement> SaveAndCloseButtons => GetDriver().FindElements(By.XPath(SaveAndCloseButtonsXPath)).ToList();


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
