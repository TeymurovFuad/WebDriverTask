using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;

namespace GmailTest.Pages.Gmail.Folders.Drafts
{
    public class DraftsFolder : DraftsFolderElements
    {
        IWebDriver webDriver { get; set; }
        public DraftsFolder(IWebDriver driver) : base(driver)
        {
            webDriver = driver;
        }

        public bool isMailBoxEmpty()
        {
            return webDriver.isElementDisplayed(NoMailsInDraftLocator);
        }

        public bool isDraftsOpened()
        {
            return webDriver.WaitUntilPageContainsTitle(FolderName);
        }
    }
}
