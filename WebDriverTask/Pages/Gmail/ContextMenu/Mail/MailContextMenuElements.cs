using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverTask.Core.Extensions;

namespace WebDriverTask.Pages.Gmail.ContextMenu.Mail
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
