using Core.Extensions;
using Core.Utils.Extensions;
using OpenQA.Selenium;

namespace Business.PageObjects.Gmail.Folders.Sent
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

        public IWebElement? FindSentMailBySubjectOrBody(string subjectOrBody)
        {
            foreach (IWebElement sentMail in SentMails)
            {
                if (sentMail.isContainsChild(By.XPath($"//span[text()='{subjectOrBody}']")))
                {
                    return sentMail;
                }
            }
            return null;
        }
    }
}
