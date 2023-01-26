using Core.Common.Pages;
using Core.Utils.Extensions;
using OpenQA.Selenium;

namespace Business.PageObjects.Gmail.ContextMenu.Mail
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
