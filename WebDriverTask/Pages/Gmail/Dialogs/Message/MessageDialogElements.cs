using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Core.Helpers;

namespace WebDriverTask.Pages.Gmail.Dialogs.Message
{
    public class MessageDialogElements : BasePage
    {
        IWebDriver webDriver { get; set; }
        public MessageDialogElements(IWebDriver driver): base(driver)
        {
            webDriver = driver;
        }

        private const string _newMailDialogHeader = "New Message";
        private readonly By _mailDialogByHeaderLocator = By.XPath("//h2[div[text()='Compose:'] and div/span[text()='{0}']]");
        private readonly By _allMailDialogsLocator = By.XPath("//h2[div[text()='Compose:']]");

        public readonly By ToLocator = By.XPath("//div[@name='to']//input");
        public IWebElement To => webDriver.FindElement(ToLocator);

        public readonly By SubjectLocator = By.XPath("//input[@name='subjectbox']");
        public IWebElement Subject => webDriver.FindElement(SubjectLocator);

        public readonly By BodyLocator = By.XPath("//div[@aria-label='Message Body']");
        public IWebElement Body => webDriver.FindElement(BodyLocator);

        public readonly By SendButtonLocator = By.XPath("//div[@role='button' and text()='Send']");
        public IWebElement SendButton => webDriver.FindElement(SendButtonLocator);

        public readonly By SaveAndCloseButtonsLocator = By.XPath("//img[@aria-label='Save & close']");
        public List<IWebElement> SaveAndCloseButtons => webDriver.FindElements(SaveAndCloseButtonsLocator).ToList();


        public List<IWebElement> MailDialogsByHeader(string dialogHeader)
        {
            string pathToDialog = StringHelper.FormatString(_mailDialogByHeaderLocator.GetLocatorValue(), dialogHeader)!;
            return webDriver.FindElements(By.XPath(pathToDialog)).ToList();
        }

        public List<IWebElement> NewMailDialogs()
        {
            string pathToDialog = StringHelper.FormatString(_mailDialogByHeaderLocator.GetLocatorValue(), _newMailDialogHeader)!;
            return webDriver.FindElements(By.XPath(pathToDialog)).ToList();
        }

        public List<IWebElement> AllMailDialogs()
        {
            return webDriver.FindElements(_allMailDialogsLocator).ToList();
        }

        public IWebElement GetMailDialog(string? mailSubject=null)
        {
            string pathToSpecifiedMessageDialog = StringHelper.FormatString(_mailDialogByHeaderLocator.GetLocatorValue(), mailSubject ?? _newMailDialogHeader)!;
            return webDriver.FindElement(By.XPath(pathToSpecifiedMessageDialog));
        }
    }
}
