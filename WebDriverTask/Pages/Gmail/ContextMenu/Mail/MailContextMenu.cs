using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverTask.Core.Extensions;

namespace WebDriverTask.Pages.Gmail.ContextMenu.Mail
{
    public class MailContextMenu : MailContextMenuElements
    {
        readonly IWebDriver webDriver;
        public MailContextMenu(IWebDriver driver) : base(driver) => webDriver = driver;

        public void ClickDelete()
        {
            DeleteItem.Click();
        }

        public void ClickArchive()
        {
            ArchiveItem.Click();
        }
    }
}
