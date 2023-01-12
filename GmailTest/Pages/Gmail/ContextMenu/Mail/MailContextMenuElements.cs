using OpenQA.Selenium;
using WebDriverTask.Common.Pages;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Utils.Extensions;

namespace GmailTest.Pages.Gmail.ContextMenu.Mail
{
    public class MailContextMenuElements : BasePage
    {
        readonly IWebDriver webDriver;
        protected MailContextMenuElements(IWebDriver driver) : base(driver) => webDriver = driver;

        public By DeleteItemLocator => By.XPath("//div[@role='menuitem']//div[text()='Delete']");
        public IWebElement DeleteItem => webDriver.GetElement(DeleteItemLocator);

        public By ArchiveItemLocator => By.XPath("//div[@role='menuitem']//div[text()='Archive']");
        public IWebElement ArchiveItem => webDriver.GetElement(ArchiveItemLocator);
    }
}
