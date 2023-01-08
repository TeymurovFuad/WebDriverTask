using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;

namespace WebDriverTask.Pages.Gmail.Dialogs.Message
{
    public class MessageDialogElements : BasePage
    {
        IWebDriver webDriver { get; set; }
        public MessageDialogElements(IWebDriver driver): base(driver)
        {
            webDriver = driver;
        }

        public readonly string newMailDialogHeader = "New Message";
        public List<IWebElement> newMailDialogs => webDriver.GetElements(MailDialogsByHeaderLocator(newMailDialogHeader));

        public By MailDialogsByHeaderLocator(string subject) => By.XPath($"//h2[div[text()='Compose:'] and div/span[text()='{subject}']]");
        public List<IWebElement> MailDialogsByHeader(string subject) => webDriver.JsGetElements(MailDialogsByHeaderLocator(subject));

        public IWebElement GetMailDialog(string? subject=null) => webDriver.GetElement(MailDialogsByHeaderLocator(subject??newMailDialogHeader));

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

        public readonly By SaveAndCloseButtonsLocator = By.XPath("//img[@aria-label='Save & close']");
        public List<IWebElement> SaveAndCloseButtons => webDriver.GetElements(SaveAndCloseButtonsLocator).ToList();
    }
}
