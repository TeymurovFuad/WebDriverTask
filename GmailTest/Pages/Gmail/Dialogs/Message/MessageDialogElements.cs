using OpenQA.Selenium;
using WebDriverTask.Common.Pages;
using WebDriverTask.Utils.Extensions;

namespace GmailTest.Pages.Gmail.Dialogs.Message
{
    public class MessageDialogElements : BasePage
    {
        IWebDriver webDriver { get; set; }
        public MessageDialogElements(IWebDriver driver) : base(driver)
        {
            webDriver = driver;
        }

        public By NewMailDialogsByHeaderLocator => By.XPath($"//h2[div[text()='Compose:'] and div/span[text()='New Message']]");
        public List<IWebElement> newMailDialogs => webDriver.GetElements(NewMailDialogsByHeaderLocator);
        public IWebElement NewMailDialog => webDriver.JsGetElement(NewMailDialogsByHeaderLocator);

        public By MailDialogsByHeaderLocator(string subject) => By.XPath($"//h2[div[text()='Compose:'] and div/span[text()='{subject}']]");
        public List<IWebElement> MailDialogsByHeader(string subject) => webDriver.JsGetElements(MailDialogsByHeaderLocator(subject));

        public IWebElement GetMailDialog(string subject) => webDriver.JsGetElement(MailDialogsByHeaderLocator(subject));

        private readonly By _allMailDialogsLocator = By.XPath("//h2[div[text()='Compose:']]");
        public List<IWebElement> AllMailDialogs => webDriver.GetElements(_allMailDialogsLocator);

        public readonly By ToLocator = By.XPath("//div[@name='to']//input");
        public IWebElement To => webDriver.GetElement(ToLocator);

        public readonly By SubjectLocator = By.XPath("//input[@name='subjectbox']");
        public IWebElement Subject => webDriver.GetElement(SubjectLocator);

        public readonly By BodyLocator = By.XPath("//div[@aria-label='Message Body']");
        public IWebElement Body => webDriver.GetElement(BodyLocator);

        public readonly By SendButtonLocator = By.XPath("//div[@role='button' and text()='Send']");
        public IWebElement SendButton => webDriver.GetElement(SendButtonLocator);

        public By MessageDialogHeaderLocator(string subject) => By.XPath($"//span[text()='{subject}']/ancestor::tr");
        public IWebElement MessageDialogHeader(string subject) => webDriver.GetElement(MessageDialogHeaderLocator(subject));

        public readonly By SaveAndCloseButtonLocator = By.XPath("//img[@aria-label='Save & close']");
        public IWebElement SaveAndCloseButton(string subject) => MessageDialogHeader(subject).GetChild(SaveAndCloseButtonLocator);
        public List<IWebElement> SaveAndCloseButtons => webDriver.GetElements(SaveAndCloseButtonLocator).ToList();

    }
}
