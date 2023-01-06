using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Core.Helpers;
using WebDriverTask.Pages.Gmail.Dialogs.Message;

namespace WebDriverTask.Pages.Gmail.Folders.Sent
{
    public class SentFolder : SentFolderElements
    {
        IWebDriver webDriver { get; set; }
        public SentFolder(IWebDriver driver) : base(driver)
        {
            webDriver = driver;
        }

        public bool isMailBoxEmpty()
        {
            return webDriver.isElementDisplayed(NoSentMessagesLocator);
        }

        public bool isSentOpened()
        {
            return webDriver.WaitUntilPageContainsTitle(FolderName);
        }
    }
}
